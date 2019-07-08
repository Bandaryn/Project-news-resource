using AutoMapper;
using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using FinalTest.Data.Contracts.IRepositories;
using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IPostRepository postRepository;
        private readonly IProfileRepository profilRepository;
        private readonly ILikeRepository likeRepository;
        private readonly IDislikeRepository dislikeRepository;

        public CommentService(ICommentRepository commentRepository, IProfileRepository profilRepository, 
            IPostRepository postRepository, ILikeRepository likeRepository, IDislikeRepository dislikeRepository)
        {
            this.commentRepository = commentRepository;
            this.profilRepository = profilRepository;
            this.postRepository = postRepository;
            this.dislikeRepository = dislikeRepository;
            this.likeRepository = likeRepository;
        }

        public void Add(CommentViewModel viewModel)
        {
            Comment comment = Mapper.Map<Comment>(viewModel);
            comment.Author = profilRepository.Get(viewModel.AuthorIds);
            comment.Post = postRepository.Get(viewModel.PostId);
            commentRepository.Add(comment);
            commentRepository.SaveChanges();
        }

        public void Delete(CommentViewModel viewModel)
        {
            foreach(var like in viewModel.Likes)
            {
                likeRepository.Remove(like.Id);
            }
            foreach(var dislike in viewModel.Dislikes)
            {
                dislikeRepository.Remove(dislike.Id);
            }
            commentRepository.Remove(viewModel.Id);

            commentRepository.SaveChanges();
        }

        public CommentViewModel Get(int id)
        {
            Comment comment = commentRepository.Get(id);

            if ((comment != null) && (comment.Likes != null))
            {
                comment.LikesAmount = comment.Likes.Count;
            }
            if ((comment != null) && (comment.Dislikes != null))
            {
                comment.DislikesAmount = comment.Dislikes.Count;
            }

            var result = Mapper.Map<CommentViewModel>(comment);

            return result;
        }

        public List<CommentViewModel> GetList()
        {
            List<Comment> commentList = commentRepository.GetList();
            List<CommentViewModel> commentModelList = new List<CommentViewModel>();
            foreach (var item in commentList)
            {
                var result = Mapper.Map<CommentViewModel>(item);
                commentModelList.Add(result);
            }

            return commentModelList;
        }

        public void Save(CommentViewModel viewModel)
        {
            commentRepository.SaveChanges();
        }

        public void Update(CommentViewModel viewModel)
        {
            Comment comment = commentRepository.Get(viewModel.Id);

            var result = Mapper.Map(viewModel, comment);
            commentRepository.SaveChanges();
        }
    }
}
