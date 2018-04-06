namespace DomainDrivenCore.SampleDomain
{
    public class Parent : Entity<Parent>
    {
        public virtual string Description { get; set; }
    }
}