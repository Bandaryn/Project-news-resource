using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts
{
    public interface IProfileService
    {
        ProfileViewModel Get(int id);
        ProfileViewModel Get(string ids);
        List<ProfileViewModel> GetList();
        void Save(ProfileViewModel viewModel);
        void Add(ProfileViewModel viewModel);
        void Delete(ProfileViewModel viewModel);
        void Update(ProfileViewModel viewModel);
    }
}
