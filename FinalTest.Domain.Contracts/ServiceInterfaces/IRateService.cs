using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts
{
    public interface IRateService
    {
        RateViewModel Get(int id);
        IList<RateViewModel> GetByAuthor(string Ids);
        List<RateViewModel> GetList();
        void Save(RateViewModel viewModel);
        void Add(RateViewModel viewModel);
        void Delete(RateViewModel viewModel);
        void Update(RateViewModel viewModel);
    }
}
