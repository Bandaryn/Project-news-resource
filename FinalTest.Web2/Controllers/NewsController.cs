using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTest.Web2.Controllers
{
    public class NewsController : Controller
    {
        private readonly IPostService postService;

        public NewsController(IPostService postService)
        {
            this.postService = postService;
        }

        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(int id)
        {
            var post = postService.Get(id);


            return View(post);
        }

        public ActionResult Add(int id)
        {
            var post = new PostViewModel();
            post.Id = id;
            return View(post);

        }

        [HttpPost]
        public ActionResult Add(PostViewModel viewModel)
        {
            viewModel.Created = DateTime.Now;

            postService.Add(viewModel);


            return RedirectToAction("Display", new { id = viewModel.Id });
        }
    }
}