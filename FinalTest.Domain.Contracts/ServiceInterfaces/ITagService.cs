using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts
{
    public interface ITagService
    {
        TagViewModel Get(int id);
        List<TagViewModel> GetList();
        void Save(TagViewModel viewModel);
        void Add(TagViewModel viewModel);
        void AddFromPost(PostViewModel viewModel);
        void Delete(TagViewModel viewModel);
        void Update(TagViewModel viewModel);
    }
}
