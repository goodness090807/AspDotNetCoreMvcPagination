namespace myfirstmvc.ViewModels.Partial
{
    public class PaginationViewModel
    {
        public int pageNum { get; set; }

        public int pageSize { get; set; }

        public int minPage { get; set; }

        public int maxPage { get; set; }

        public int TotalPage { get; set; }
    }
}