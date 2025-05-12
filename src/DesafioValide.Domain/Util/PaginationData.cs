namespace DesafioValide.Domain.Util
{
    public class PaginationData<T>
    {
        public PaginationData(List<T> data, int page, int limit, long totalRecords)
        {
            Data = data;
            Page = page;
            Limit = limit;
            TotalRecords = totalRecords;
        }

        public List<T> Data { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public long TotalRecords { get; set; }
    }
}
