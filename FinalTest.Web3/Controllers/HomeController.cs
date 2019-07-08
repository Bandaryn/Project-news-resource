using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using FinalTest.Web3.Filters;
using FinalTest.Web3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTest.Web3.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        

        public HomeController(IPostService postService)
        {
            this.postService = postService;
           
        }

        public ActionResult Index()
        {
            

            var postList = postService.GetList();

            return View(postList);
        }

       
        public ActionResult NewsSorted(string sortBy)
        {
            switch (sortBy)
            {
                case "rating":
                    var postListRate = postService.GetList();

                    Sorter sorterRate = new Sorter();

                    postListRate.Sort(sorterRate);

                    return PartialView("MostRated", postListRate);
                case "latest":
                    var postListDate = postService.GetList();

                    SorterDate sorterDate = new SorterDate();

                    postListDate.Sort(sorterDate);

                    return PartialView("LatestNews", postListDate);
                default:
                    var postList = postService.GetList();

                    SorterDate sorter = new SorterDate();

                    postList.Sort(sorter);

                    return PartialView("LatestNews", postList);
            }
            
                
            
            
        }
       
        [HttpPost]
        public ActionResult Search(SearchViewModel viewModel)
        {
            var postList = postService.Search(viewModel.Request);

            return View("SearchResult", postList);
        }

       

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "ru", "en"};
            if (!cultures.Contains(lang))
            {
                lang = "en";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        public ActionResult ChangeTheme(string theme)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список тем
            List<string> themes = new List<string>() { "light", "dark" };
            if (!themes.Contains(theme))
            {
                theme = "light";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["theme"];
            if (cookie != null)
                cookie.Value = theme;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("theme");
                cookie.HttpOnly = false;
                cookie.Value = theme;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        public class Sorter : IComparer<PostViewModel>
        {
            public int Compare(PostViewModel x, PostViewModel y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return y.Rating.CompareTo(x.Rating);
            }
        }

        public class SorterDate : IComparer<PostViewModel>
        {
            public int Compare(PostViewModel x, PostViewModel y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return y.Created.CompareTo(x.Created);
            }
        }
    }
}