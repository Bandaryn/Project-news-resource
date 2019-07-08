using AutoMapper;
using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Services
{
    public class LikeService: ILikeService
    {
        private readonly ILikeRepository repository;
        private readonly ICommentRepository commentRepository;

        public LikeService(ILikeRepository repository, ICommentRepository commentRepository)
        {
            this.repository = repository;
            this.commentRepository = commentRepository;
        }

        public void Add(LikeViewModel viewModel)
        {
            Like like = Mapper.Map<Like>(viewModel);

            like.Comment = commentRepository.Get(viewModel.CommentId);

            repository.Add(like);

            repository.SaveChanges();
        }

        public void Delete(LikeViewModel viewModel)
        {
            repository.Remove(viewModel.Id);
            repository.SaveChanges();
        }

        public LikeViewModel Get(int id)
        {
            Like like = repository.Get(id);
            var result = Mapper.Map<LikeViewModel>(like);

            return result;
        }

        public List<LikeViewModel> GetByAuthor(string Ids)
        {
            IList<Like> likeList = repository.GetByAuthor(Ids);

            List<LikeViewModel> likeModelList = new List<LikeViewModel>();
            foreach (var item in likeList)
            {
                var result = Mapper.Map<LikeViewModel>(item);
                likeModelList.Add(result);
            }

            return likeModelList;
        }

        public void Save(LikeViewModel viewModel)
        {
            repository.SaveChanges();
        }

        public void Update(LikeViewModel viewModel)
        {
            Like like = repository.Get(viewModel.Id);
            var result = Mapper.Map(viewModel, like);

            repository.SaveChanges();
        }
    }
}
