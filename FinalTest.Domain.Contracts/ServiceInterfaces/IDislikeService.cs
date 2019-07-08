using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts.ServiceInterfaces
{
    public interface IDislikeService
    {
        DislikeViewModel Get(int id);
        List<DislikeViewModel> GetByAuthor(string Ids);
        void Save(DislikeViewModel viewModel);
        void Add(DislikeViewModel viewModel);
        void Delete(DislikeViewModel viewModel);
        void Update(DislikeViewModel viewModel);
    }
}
