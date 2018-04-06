using DomainDrivenCore.Migration;
using FluentMigrator;

namespace DomainDrivenCore.SampleMigration
{
    [Migration(1)]
    public class MigrationStep001 : FluentMigrator.Migration
    {
        private const string ParentTable = "Parent";
        private const string ChildTable = "Child";

        public override void Up()
        {
            this.CreateEntityTable(ParentTable)
                .WithStringColumn("Description");
            this.CreateEntityTable(ChildTable)
                .WithStringColumn("Description")
                .WithForeignKey(ParentTable);
            this.EnforceForeignKey(ChildTable, ParentTable);
        }

        public override void Down()
        {
            Delete.Table(ChildTable);
            Delete.Table(ParentTable);
        }
    }
}