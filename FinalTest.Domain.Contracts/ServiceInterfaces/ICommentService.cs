using FinalTest.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Domain.Contracts
{
    public interface ICommentService
    {
        CommentViewModel Get(int id);
        List<CommentViewModel> GetList();
        void Save(CommentViewModel viewModel);
        void Add(CommentViewModel viewModel);
        void Delete(CommentViewModel viewModel);
        void Update(CommentViewModel viewModel);
    }
}
