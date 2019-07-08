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
    public class RateService:IRateService
    {
        private readonly IRateRepository repository;
        private readonly IPostRepository postRepository;

        public RateService(IRateRepository repository, IPostRepository postRepository)
        {
            this.repository = repository;
            this.postRepository = postRepository;
        }

        public void Add(RateViewModel viewModel)
        {
            Rate rate = Mapper.Map<Rate>(viewModel);

            rate.Post = postRepository.Get(viewModel.PostId);
            
            repository.Add(rate);
            repository.SaveChanges();
        }

        public void Delete(RateViewModel viewModel)
        {
            repository.Remove(viewModel.Id);
            repository.SaveChanges();
        }

        public RateViewModel Get(int id)
        {
            Rate rate = repository.Get(id);
            var result = Mapper.Map<RateViewModel>(rate);

            return result;
        }

        public IList<RateViewModel> GetByAuthor(string Ids)
        {
            IList<Rate> rateList = repository.GetByAuthor(Ids);

            List<RateViewModel> rateModelList = new List<RateViewModel>();
            foreach (var item in rateList)
            {
                var result = Mapper.Map<RateViewModel>(item);
                rateModelList.Add(result);
            }

            return rateModelList;
        }

        public List<RateViewModel> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save(RateViewModel viewModel)
        {
            repository.SaveChanges();
        }

        public void Update(RateViewModel viewModel)
        {
            Rate rate = repository.Get(viewModel.Id);
            var result = Mapper.Map(viewModel, rate);

            repository.SaveChanges();
        }
    }
}
