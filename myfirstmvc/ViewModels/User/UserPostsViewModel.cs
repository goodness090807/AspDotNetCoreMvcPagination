using System.Collections.Generic;
using myfirstmvc.ViewModels.Partial;
using myfirstmvc.ViewModels.Post;

namespace myfirstmvc.ViewModels.User
{
    public class UserPostsViewModel
    {        
        public int Id { get; set; }

        public string UserName { get; set; }

        public int Gender { get; set; }

        public PaginationViewModel Pagination { get; set; }

        public List<PostReadViewModel> Posts { get; set; }
    }
}