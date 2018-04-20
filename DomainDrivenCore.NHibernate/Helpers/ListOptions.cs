namespace DomainDrivenCore.NHibernate.Helpers
{
    public class ListOptions
    {
        public ListOptions()
        {
            PageSize = 20;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}