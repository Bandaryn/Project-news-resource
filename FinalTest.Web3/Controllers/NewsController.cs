using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ServiceInterfaces;
using FinalTest.Domain.Contracts.ViewModels;
using FinalTest.Web3.Filters;
using FinalTest.Web3.Hubs;
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
    public class NewsController : Controller
    {
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly IRateService rateService;
        private readonly ILikeService likeService;
        private readonly IDislikeService dislikeService;
        private readonly ITagService tagService;

        public NewsController(IPostService postService, ICommentService commentService,IRateService rateService, 
            ILikeService likeService, IDislikeService dislikeService,ITagService tagService)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.rateService = rateService;
            this.likeService = likeService;
            this.dislikeService = dislikeService;
            this.tagService = tagService;
        }

        // GET: News
        public ActionResult Index()
        {
            var postList = postService.GetList();
            return View(postList);
        }

        public ActionResult Display(int id)
        {
            var currentUserId = User.Identity.GetUserId();

            

            var post = postService.Get(id);
           

            if (User.IsInRole("reader") || User.IsInRole("writer") || User.IsInRole("admin"))
            {
                post.IsCommentable = true;

                if (rateService.GetByAuthor(currentUserId) == null)
                {
                    post.IsRatable = true;
                }
                else
                {
                    post.IsRatable = true;


                    var rateList = rateService.GetByAuthor(currentUserId);
                    foreach (var rate in rateList)
                    {
                        if (rate.PostId == id)
                        {
                            post.IsRatable = false;
                        }
                    }

                }

                if (post.Comments != null)
                {
                    foreach (var comment in post.Comments)
                    {
                        if (likeService.GetByAuthor(currentUserId) == null)
                        {
                            if(dislikeService.GetByAuthor(currentUserId) == null)
                            {
                                comment.IsLikable = true;
                            }
                            
                        }
                        else
                        {
                            comment.IsLikable = true;
                            var likeList = likeService.GetByAuthor(currentUserId);
                            var dislikeList = dislikeService.GetByAuthor(currentUserId);
                            foreach (var like in likeList)
                            {
                                if (like.CommentId == comment.Id)
                                {
                                    comment.IsLikable = false;
                                }
                            }
                            foreach (var dislike in dislikeList)
                            {
                                if (dislike.CommentId == comment.Id)
                                {
                                    comment.IsLikable = false;
                                }
                            }
                        }
                    }
                    foreach(var comment in post.Comments)
                    {
                        if (User.IsInRole("admin"))
                        {
                            comment.IsEditable = true;
                        }
                        else
                        {
                            if(comment.AuthorIds == currentUserId)
                            {
                                comment.IsEditable = true;
                            }
                            else
                            {
                                comment.IsEditable = false;
                            }
                        }
                    }
                }
            
            }
            else
            {
                post.IsRatable = false;
                foreach(var comment in post.Comments)
                {
                    comment.IsLikable = false;
                    comment.IsEditable = false;
                }
                post.IsCommentable = false;
            }


            return View(post);
        }

        [Authorize(Roles="admin,writer")]         
        public ActionResult Add()
        {
            var post = new PostViewModel()
            {
                
                Created = DateTime.Now,
                SectionsAvailable=new List < SelectListItem >{
                    new SelectListItem { Text = "C", Value = "1" },
                    new SelectListItem { Text = "Java", Value = "2" },
                    new SelectListItem { Text = "AI", Value = "3" }

                }

            };
            var tagList = tagService.GetList();


            post.TagSuggested = new string[tagList.Count];

            for(int i = 0;i<tagList.Count; i++)
            {
                post.TagSuggested[i] = tagList[i].Name;
            }
            
            

            return View(post);

        }

        [HttpPost]
        public ActionResult Add(PostViewModel viewModel)
        {
            viewModel.AuthorIds = User.Identity.GetUserId();
            viewModel.Created = DateTime.Now;
            if (viewModel.Id == 0)
            {
                for (int i = 1; ; i++)
                {
                    if (postService.Get(i) == null)
                    {
                        viewModel.Id = i;
                        tagService.AddFromPost(viewModel);
                        postService.Add(viewModel);
                        break;
                    }
                }

            }



            return RedirectToAction("Display", new { id = viewModel.Id });
        }

        [Authorize(Roles = "admin,writer")]
        public ActionResult Edit (int id)
        {
            
            var post = postService.Get(id);
            var userid = User.Identity.GetUserId();
            if((post.AuthorIds == userid) || (User.IsInRole("admin")))
            {
                post.SectionsAvailable = new List<SelectListItem>{
                    new SelectListItem { Text = "C", Value = "1" },
                    new SelectListItem { Text = "Java", Value = "2" },
                    new SelectListItem { Text = "AI", Value = "3" }

                };

                var tagList = tagService.GetList();


                post.TagSuggested = new string[tagList.Count];

                for (int i = 0; i < tagList.Count; i++)
                {
                    post.TagSuggested[i] = tagList[i].Name;
                }

                if (post.Tags != null)
                {
                    foreach (var tag in post.Tags)
                    {
                        post.TagsName += tag.Name;
                        if (post.Tags[post.Tags.Count-1] != tag)
                        {
                            post.TagsName += ",";
                        }

                    }
                }
                



                return View(post);

            }

            return View("Display", post);
            
        }

        [HttpPost]
        public ActionResult Edit(PostViewModel viewModel)
        {
            tagService.AddFromPost(viewModel);
            postService.Update(viewModel);

            return RedirectToAction("Display", new { id = viewModel.Id });
        }

        [Authorize(Roles = "admin,writer")]
        public ActionResult Delete(int id)
        {

            var post = postService.Get(id);
            var userid = User.Identity.GetUserId();
            if ((post.AuthorIds == userid) || (User.IsInRole("admin")))
            {
                return View(post);
            }

            return View("Display", post);


        }

        [HttpPost]
        public ActionResult Delete(PostViewModel viewModel)
        {
            postService.Delete(viewModel);

            return RedirectToAction("MyProfile","Profile");
        }

        

        [HttpPost]
        [Authorize]        
        public ActionResult AddComment(CommentViewModel viewModel)
        {
            viewModel.AuthorIds = User.Identity.GetUserId();
            if (viewModel.Id == 0)
            {
                var listComment = commentService.GetList();
                
                commentService.Add(viewModel);
                
            }

            var listComment2 = commentService.GetList();
            var comment = commentService.Get(listComment2[listComment2.Count - 1].Id);

            AddToPage(comment.Body,comment.AuthorName,comment.LikesAmount,comment.DislikesAmount,comment.Id);
            
            return PartialView("CommentAdd");
        }

        public void AddToPage(string body, string authorname, int likesamount,int dislikesamount, int id)
        {
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<CommentHub>();

            context.Clients.All.displayComment(body, authorname,likesamount,dislikesamount,id);
            

        }

        [HttpPost]
        public ActionResult DeleteComment(int Id)
        {
            var viewModel = commentService.Get(Id);
            commentService.Delete(viewModel);
            return PartialView();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Rate(RateViewModel viewModel)
        {
            viewModel.AuthorIds = User.Identity.GetUserId();
            if (viewModel.Id == 0)
            {
                for (int i = 1; ; i++)
                {
                    if (rateService.Get(i) == null)
                    {
                        viewModel.Id = i;
                        rateService.Add(viewModel);
                        break;
                    }
                }

            }
            
            var post = postService.Get(viewModel.PostId);

            postService.Update(post);

            
            return PartialView(post);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Like(LikeViewModel viewModel)
        {
            viewModel.AuthorIds = User.Identity.GetUserId();
            if (viewModel.Id == 0)
            {
                for (int i = 1; ; i++)
                {
                    if (likeService.Get(i) == null)
                    {
                        viewModel.Id = i;
                        likeService.Add(viewModel);
                        break;
                    }
                }

            }

            var comment = commentService.Get(viewModel.CommentId);
            commentService.Update(comment);

            if (User.IsInRole("admin"))
            {
                comment.IsEditable = true;
            }
            else
            {
                if (comment.AuthorIds == User.Identity.GetUserId())
                {
                    comment.IsEditable = true;
                }
                else
                {
                    comment.IsEditable = false;
                }
            }

            return PartialView(comment);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Dislike(DislikeViewModel viewModel)
        {
            viewModel.AuthorIds = User.Identity.GetUserId();
            if (viewModel.Id == 0)
            {
                for (int i = 1; ; i++)
                {
                    if (dislikeService.Get(i) == null)
                    {
                        viewModel.Id = i;
                        dislikeService.Add(viewModel);
                        break;
                    }
                }

            }

            var comment = commentService.Get(viewModel.CommentId);
            commentService.Update(comment);

            if (User.IsInRole("admin"))
            {
                comment.IsEditable = true;
            }
            else
            {
                if (comment.AuthorIds == User.Identity.GetUserId())
                {
                    comment.IsEditable = true;
                }
                else
                {
                    comment.IsEditable = false;
                }
            }

            return PartialView("Like",comment);
        }

    }
}