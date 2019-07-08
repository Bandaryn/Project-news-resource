using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTest.Web3.Hubs
{
    public class CommentHub : Hub
    {
        //private readonly ICommentService commentService;

        //public CommentHub(ICommentService commentService)
        //{
        //    this.commentService = commentService;
        //}

        //public void Announce(string message)
        //{

        //    Clients.All.Announce(message);

        //}

        //public DateTime GetServerDateTime()
        //{
        //    return DateTime.Now;
        //}

        //public void NewComment(string message, string authorIds)
        //{
            //var comment = new CommentViewModel();
            //comment.Body = message;
            //comment.AuthorIds = authorIds;
            //comment.LikesAmount = 0;

            //for (int i = 1; ; i++)
            //{
            //    if (commentService.Get(i) == null)
            //    {
            //        comment.Id = i;
            //        commentService.Add(comment);
            //        break;
            //    }
            //}

        //    Clients.All.AnnounceComment(message, authorIds);
        //}
    }
}