using FluentMigrator.Builders.Create.Table;

namespace DomainDrivenCore.Migration
{
    public static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax CreateEntityTable(
            this FluentMigrator.Migration migration, string tableName)
        {
            return migration.Create.Table(tableName)
                .WithColumn("Id").AsInt64().PrimaryKey()
                .WithColumn("[Version]").AsInt32().NotNullable()
                .WithColumn("Created").AsDateTime().NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithStringColumn(
            this ICreateTableColumnOptionOrWithColumnSyntax syntax, string column, int length = 255,
            bool nullable = false)
        {
            var columnSyntax = syntax.WithColumn(column).AsString(length);
            return nullable
                ? columnSyntax.Nullable()
                : columnSyntax.NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithForeignKey(
            this ICreateTableColumnOptionOrWithColumnSyntax syntax, string foreignKeyTable, bool nullable = false)
        {
            var columnSyntax = syntax.WithColumn($"{foreignKeyTable}Id").AsInt64();
            return nullable
                ? columnSyntax.Nullable()
                : columnSyntax.NotNullable();
        }

        public static void EnforceForeignKey(this FluentMigrator.Migration migration, string fromTable, string toTable)
        {
            var keyName = $"FK_{fromTable}_{toTable}";
            migration.Create.ForeignKey(keyName)
                .FromTable(fromTable)
                .ForeignColumn($"{toTable}Id")
                .ToTable(toTable)
                .PrimaryColumn("Id");
        }

        public static void EnforceForeignKey(this FluentMigrator.Migration migration, string fromTable, string toTable,
            string property)
        {
            var keyName = $"FK_{fromTable}_{toTable}_{property}";
            migration.Create.ForeignKey(keyName)
                .FromTable(fromTable)
                .ForeignColumn($"{property}Id")
                .ToTable(toTable)
                .PrimaryColumn("Id");
        }
    }
}