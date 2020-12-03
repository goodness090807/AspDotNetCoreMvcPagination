using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfirstmvc.Data;
using myfirstmvc.Models;
using myfirstmvc.Service;
using myfirstmvc.ViewModels.Partial;
using myfirstmvc.ViewModels.Post;
using myfirstmvc.ViewModels.User;

namespace myfirstmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IPaginationService _paginationService;

        public HomeController(DataContext context, IPaginationService paginationService)
        {
            _context = context;
            _paginationService = paginationService;
        }

        public IActionResult Index(int pageNum = 1, int pageSize = 6)
        {
            List<UserReadViewModel> users = _context.appUsers.OrderBy(x => x.Id).Skip((pageNum - 1) * pageSize).Take(pageSize)
                                            .Select(n => new UserReadViewModel
                                            {
                                                Id = n.Id,
                                                UserName = n.UserName,
                                                Gender = n.Gender
                                            }).ToList();
            int TotalPage = (int)Math.Ceiling(Decimal.Divide(_context.appUsers.ToList().Count, pageSize));

            PaginationViewModel pagination = _paginationService.GetPagination(pageNum, pageSize, TotalPage);
            UserPaginationViewModel PageData = new UserPaginationViewModel()
            {
                pagination = pagination,
                users = users
            };

            return View(PageData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAdd(UserCreateViewModel userCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var appUser = new AppUsers()
            {
                UserName = userCreateViewModel.UserName,
                Gender = userCreateViewModel.Gender
            };

            _context.appUsers.Add(appUser);

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UserDetail(int Id, int pageNum = 1, int pageSize = 2)
        {
            var userPosts = new UserPostsViewModel();
            var user = _context.appUsers.FirstOrDefault(x => x.Id == Id);

            userPosts.Id = user.Id;
            userPosts.UserName = user.UserName;
            userPosts.Gender = user.Gender;

            var posts = _context.posts.Where(x => x.UserId == Id).OrderBy(x => x.Id).Skip((pageNum - 1) * pageSize).Take(pageSize).Select(
                y => new PostReadViewModel
                {
                    Id = y.Id,
                    Title = y.Title,
                    Content = y.Content,
                    UserId = y.UserId
                }
            ).ToList();

            userPosts.Posts = posts;

            int TotalPage = (int)Math.Ceiling(Decimal.Divide(_context.posts.Where(x => x.UserId == Id).ToList().Count, pageSize));

            PaginationViewModel pagination = _paginationService.GetPagination(pageNum, pageSize, TotalPage);

            userPosts.Pagination = pagination;
            
            return View(userPosts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
