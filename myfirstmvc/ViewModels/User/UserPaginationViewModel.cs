using System.Collections.Generic;
using myfirstmvc.ViewModels.Partial;

namespace myfirstmvc.ViewModels.User
{
    public class UserPaginationViewModel
    {
        public PaginationViewModel pagination { get; set; }
        public List<UserReadViewModel> users { get; set; }
    }
}