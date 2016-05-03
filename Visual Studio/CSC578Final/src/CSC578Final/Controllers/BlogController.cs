using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace CSC578Final.Controllers
{
    using System.Security.Claims;
    using AutoMapper;

    using CSC578Final.Models;
    using CSC578Final.ViewModels;

    using Microsoft.AspNet.Authorization;
    using System.Security.Claims;

    
    public class BlogController : Controller
    {
        private readonly IBlogRepository repository;

        public BlogController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var posts = this.repository.GetPostViews().OrderByDescending(row => row.Created);


            return View(posts);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = this.repository.GetPost(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(new EditPostViewModel(post));
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(EditPostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var existingPost = this.repository.GetPost(vm.Id);
                var updatedPost = Mapper.Map<EditPostViewModel, Post>(vm, existingPost);
                this.repository.EditPost(updatedPost);
                this.repository.SaveAll();
            }            

            return RedirectToAction("Index", "Blog");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePostViewModel());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(CreatePostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newPost = Mapper.Map<Post>(vm);
                newPost.AuthorId = this.User.GetUserId();
                newPost.Created = DateTime.UtcNow;
                newPost.Edited = DateTime.UtcNow;
                this.repository.AddPost(newPost);
                this.repository.SaveAll();
            }            

            return RedirectToAction("Index", "Blog");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            this.repository.RemoveTrip(id);
            this.repository.SaveAll();
            return RedirectToAction("Index", "Blog");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
