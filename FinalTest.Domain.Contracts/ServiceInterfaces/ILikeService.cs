using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts
{
    public interface ILikeService
    {
        LikeViewModel Get(int id);
        List<LikeViewModel> GetByAuthor(string Ids);
        void Save(LikeViewModel viewModel);
        void Add(LikeViewModel viewModel);
        void Delete(LikeViewModel viewModel);
        void Update(LikeViewModel viewModel);
    }
}
