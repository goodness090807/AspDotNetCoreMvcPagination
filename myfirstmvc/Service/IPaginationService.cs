using myfirstmvc.ViewModels.Partial;

namespace myfirstmvc.Service
{
    public interface IPaginationService
    {
        PaginationViewModel GetPagination(int pageNum, int pageSize, int TotalPage);
    }
}