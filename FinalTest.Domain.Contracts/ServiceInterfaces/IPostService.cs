using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts
{
    public interface IPostService
    {
        PostViewModel Get(int id);
        List<PostViewModel> GetList();
        List<PostViewModel> Search(string request);
        void Save(PostViewModel viewModel);
        void Add(PostViewModel viewModel);
        void Delete(PostViewModel viewModel);
        void Update(PostViewModel viewModel);
    }
}
