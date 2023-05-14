namespace Fashion_store_web.Options
{
    public class GenericResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public long TotalCount { get; set; }
    }
}
