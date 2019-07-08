using AutoMapper;
using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using FinalTest.Data.Contracts.IRepositories;
using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ServiceInterfaces;
using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Services
{
    public class DislikeService : IDislikeService
    {
        private readonly IDislikeRepository repository;
        private readonly ICommentRepository commentRepository;

        public DislikeService(IDislikeRepository repository, ICommentRepository commentRepository)
        {
            this.repository = repository;
            this.commentRepository = commentRepository;
        }

        public void Add(DislikeViewModel viewModel)
        {
            Dislike dislike = Mapper.Map<Dislike>(viewModel);

            dislike.Comment = commentRepository.Get(viewModel.CommentId);

            repository.Add(dislike);

            repository.SaveChanges();
        }

        public void Delete(DislikeViewModel viewModel)
        {
            repository.Remove(viewModel.Id);
            repository.SaveChanges();
        }

        public DislikeViewModel Get(int id)
        {
            Dislike dislike = repository.Get(id);
            var result = Mapper.Map<DislikeViewModel>(dislike);

            return result;
        }

        public List<DislikeViewModel> GetByAuthor(string Ids)
        {
            IList<Dislike> dislikeList = repository.GetByAuthor(Ids);

            List<DislikeViewModel> dislikeModelList = new List<DislikeViewModel>();
            foreach (var item in dislikeList)
            {
                var result = Mapper.Map<DislikeViewModel>(item);
                dislikeModelList.Add(result);
            }

            return dislikeModelList;
        }

        public void Save(DislikeViewModel viewModel)
        {
            repository.SaveChanges();
        }

        public void Update(DislikeViewModel viewModel)
        {
            Dislike dislike = repository.Get(viewModel.Id);
            var result = Mapper.Map(viewModel, dislike);

            repository.SaveChanges();
        }

       
    }
}
