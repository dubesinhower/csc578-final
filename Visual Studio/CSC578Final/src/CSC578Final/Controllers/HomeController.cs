using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace CSC578Final.Controllers
{
    using CSC578Final.Models;

    public class HomeController : Controller
    {
        private BlogContext context;

        public HomeController(BlogContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var posts = this.context.Posts.OrderBy(t => t.Created).ToList();
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
