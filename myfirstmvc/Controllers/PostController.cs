using System.Linq;
using Microsoft.AspNetCore.Mvc;
using myfirstmvc.Data;
using myfirstmvc.Models;
using myfirstmvc.ViewModels.Post;

namespace myfirstmvc.Controllers
{
    public class PostController : Controller
    {
        public DataContext _context { get; }

        public PostController(DataContext context)
        {
            _context = context;
        }

        public IActionResult PostDetail(int Id, int UserId)
        {
            var UserPosts = _context.posts.FirstOrDefault(x => x.UserId == UserId && x.Id == Id);
            return View();
        }

        public IActionResult PostAdd(int UserId)
        {
           PostCreateViewModel postCreateViewModel = new PostCreateViewModel(){
               UserId = UserId
           };
           return View(postCreateViewModel);
        }

        [HttpPost]
        public IActionResult PostAdd(PostCreateViewModel postCreateViewModel)
        {
            var post = new Posts(){
                Title = postCreateViewModel.Title,
                Content = postCreateViewModel.Content,
                UserId = postCreateViewModel.UserId
            };

            _context.posts.Add(post);

            _context.SaveChanges();

             return RedirectToAction("UserDetail", "Home", new {Id = postCreateViewModel.UserId});
        }

    }
}