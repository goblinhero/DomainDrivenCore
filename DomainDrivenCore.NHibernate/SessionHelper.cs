using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DomainDrivenCore.NHibernate.Listeners;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Event;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Type;

namespace DomainDrivenCore.NHibernate
{
    public class SessionHelper : BaseExecutable
    {
        private static ISessionFactory _sessionFactory;

        public static void Initialize(bool createDatabase, string connectionString, params Type[] mappingTypes)
        {
            var modelMapper = new ModelMapper();
            var mappings = mappingTypes
                .Select(Assembly.GetAssembly)
                .Distinct()
                .SelectMany(a => a.GetExportedTypes());
            modelMapper.AddMappings(mappings);
            modelMapper.BeforeMapManyToOne += (modelInspector, propertyPath, map) =>
                map.Column(propertyPath.LocalMember.Name + "Id");
            modelMapper.BeforeMapProperty += (inspector, member, customizer) =>
            {
                if (member.GetRootMember().MemberType == MemberTypes.Property &&
                    ((PropertyInfo) member.GetRootMember()).PropertyType == typeof(DateTime))
                    customizer.Type<UtcDateTimeType>();
            };
            var configuration = new Configuration()
                .DataBaseIntegration(dbcp =>
                {
                    dbcp.ConnectionString = connectionString;
                    dbcp.Driver<SqlClientDriver>();
                    dbcp.Dialect<MsSql2012Dialect>();
                });
            configuration.AddDeserializedMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities(), "mappings");
            configuration.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[]
            {
                new SetCreationDateListener(),
                new CheckValidityListener()
            };
            configuration.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[]
            {
                new CheckValidityListener()
            };
            if (createDatabase)
                new SchemaExport(configuration).Execute(true, true, false);
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public bool TryCreateEntity<T>(IEntityCreator<T> creator, out long? assignedId, out IEnumerable<string> errors)
            where T : IEntity
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                if (!creator.TryCreate(session, out var entity, out errors) || !entity.IsValid(out errors))
                {
                    assignedId = null;
                    return false;
                }
                session.Save(entity);
                assignedId = entity.Id;
                tx.Commit();
                return Success(out errors);
            }
        }

        public bool TryUpdateEntity<T>(IEntityUpdater<T> updater, long id, out IEnumerable<string> errors)
            where T : IEntity
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var entity = session.Get<T>(id);
                if (entity == null)
                {
                    tx.Rollback();
                    errors = new[] {$"{typeof(T).Name} with Id: {id} was not found"};
                    return false;
                }
                if (!updater.TryUpdate(session, entity, out errors) || !entity.IsValid(out errors))
                {
                    tx.Rollback();
                    return false;
                }
                tx.Commit();
                return Success(out errors);
            }
        }

        public bool TryDeleteEntity<T>(long id, out IEnumerable<string> errors)
            where T : IEntity
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var entity = session.Get<T>(id);
                if (entity == null)
                {
                    tx.Rollback();
                    return Error(out errors, $"{typeof(T).Name} with Id: {id} was not found");
                }
                session.Delete(entity);
                tx.Commit();
                return Success(out errors);
            }
        }

        public bool TryExecuteQuery<T>(IExecutableQuery<T> query, out T result, out IEnumerable<string> errors)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                if (!query.TryExecute(session, out result, out errors))
                {
                    tx.Rollback();
                    return false;
                }
                tx.Commit();
                return Success(out errors);
            }
        }

        public bool TryExecuteCommand(IExecutableCommand query, out IEnumerable<string> errors)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                if (!query.TryExecute(session, out errors))
                {
                    tx.Rollback();
                    return false;
                }
                tx.Commit();
                return Success(out errors);
            }
        }
    }
}