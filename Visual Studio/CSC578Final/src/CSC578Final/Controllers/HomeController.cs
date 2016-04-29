using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace CSC578Final.Controllers
{
    using CSC578Final.Models;

    using Microsoft.AspNet.Authorization;

    public class HomeController : Controller
    {
        private IBlogRepository repository;

        public HomeController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Posts()
        {
            var posts = this.repository.GetPosts();
            return View(posts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
