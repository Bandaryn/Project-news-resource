using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using FinalTest.Web3.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTest.Web3.Controllers
{
    [Culture]
    public class TagController : Controller
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        
        
        public ActionResult DisplayNews(int id)
        {
            var tag = tagService.Get(id);

            var newsList = tag.Posts;

            return View(newsList);
        }

        [ChildActionOnly]
        public ActionResult Cloud()
        {
            var result = tagService.GetList();

            return PartialView(result);
        }
    }
}