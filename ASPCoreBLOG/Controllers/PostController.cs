using ASPCoreBLOG.Services;
using ASPCoreBLOG.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreBLOG.Controller
{
    public class PostController: Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var vm = _postService.All().Select(x => new PostViewModel
            {
                Comments = x.Comments,
                Content = x.Content,
                Id = x.Id,
                Title = x.Title,
                Time = x.Time
            }).ToList();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var vm = _postService.Detail(id);

            return View(new PostViewModel { Comments = vm.Comments, Content = vm.Content, Id = vm.Id, Title = vm.Title,Time = vm.Time });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string title, string content)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content)) return NoContent();
            _postService.Add(new Models.Post { Content = content, Title = title, Id = _postService.All().Count + 1 });
            return new RedirectToActionResult("All", "Post", null);
        }

        [HttpPost]
        public IActionResult addComment(int id,string comment)
        {
            _postService.AddComment(id, new Models.Comment { PostId = id, Content = comment });
            return new RedirectToActionResult("Detail", "Post", new { id = id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _postService.Detail(id);
            var vm = new PostViewModel { Title = post.Title, Content = post.Content, Id = post.Id, Time = post.Time };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id,string title, string content)
        {
            _postService.Edit(new Models.Post { Id = id, Comments = _postService.Detail(id).Comments, Content = content, Time = DateTime.Now, Title = title });
            return new RedirectToActionResult("All", "Post", null);
        }
    }
}
