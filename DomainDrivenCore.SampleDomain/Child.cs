namespace DomainDrivenCore.SampleDomain
{
    public class Child : Entity<Child>
    {
        protected Child()
        {
        }

        public Child(Parent parent)
        {
            Parent = parent;
        }

        public virtual string Description { get; set; }
        public virtual Parent Parent { get; protected set; }
    }
}