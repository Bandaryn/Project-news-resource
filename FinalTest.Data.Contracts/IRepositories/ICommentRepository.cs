using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts
{
    public interface ICommentRepository
    {
        Comment Get(int id);
        Comment Get(string Ids);
        List<Comment> GetList();
        void Add(Comment entity);
        void Update(Comment entity);
        void Remove(int id);
        void SaveChanges();
    }
}
