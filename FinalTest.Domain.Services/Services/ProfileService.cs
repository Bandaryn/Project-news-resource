using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository repository;

        public ProfileService(IProfileRepository repository)
        {
            this.repository = repository;
        }

        public void Add(ProfileViewModel viewModel)
        {
            Profil profile = Mapper.Map<Profil>(viewModel);
            repository.Add(profile);
            repository.SaveChanges();
        }

        public void Delete(ProfileViewModel viewModel)
        {
            repository.Remove(viewModel.Id);
            repository.SaveChanges();
        }

        public ProfileViewModel Get(int id)
        {
            Profil profile = repository.Get(id);
            var result = Mapper.Map<ProfileViewModel>(profile);

            return result;
        }

        public ProfileViewModel Get(string ids)
        {
            
            Profil profile = repository.Get(ids);
            var result = Mapper.Map<ProfileViewModel>(profile);

            return result;
        }

        public List<ProfileViewModel> GetList()
        {
            List<Profil> profileList = repository.GetList();
            List<ProfileViewModel> profileModelList = new List<ProfileViewModel>();
            foreach (var item in profileList)
            {
                var result = Mapper.Map<ProfileViewModel>(item);
                profileModelList.Add(result);
            }
            return profileModelList;
        }

        public void Save(ProfileViewModel viewModel)
        {
            repository.SaveChanges();
        }

        public void Update(ProfileViewModel viewModel)
        {
            Profil profile = repository.Get(viewModel.Id);
            var result = Mapper.Map(viewModel, profile);

            repository.SaveChanges();
        }
    }
}
