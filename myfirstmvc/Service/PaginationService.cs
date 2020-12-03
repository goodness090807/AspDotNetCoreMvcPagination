using myfirstmvc.ViewModels.Partial;

namespace myfirstmvc.Service
{
    public class PaginationService : IPaginationService
    {
        public PaginationViewModel GetPagination(int pageNum, int pageSize, int TotalPage)
        {
            PaginationViewModel pagination = new PaginationViewModel();

            pagination.TotalPage = TotalPage;
            pagination.pageNum = pageNum;
            pagination.pageSize = pageSize;
            pagination.minPage = 2;
            pagination.maxPage = 5;

            if(TotalPage <= 7)
            {
                pagination.maxPage = TotalPage - 1;
            }
            else if (pageNum >= 5)
            {
                if(pageNum + 3 >= pagination.TotalPage)
                {
                    pagination.maxPage = pagination.TotalPage - 1;
                    pagination.minPage = pagination.TotalPage - 4;
                }
                else
                {
                    pagination.minPage = pageNum - 2;
                    pagination.maxPage = pageNum + 2;
                }
            }

            return pagination;
        }
    }
}