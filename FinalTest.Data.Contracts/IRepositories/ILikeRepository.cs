using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts
{
    public interface ILikeRepository
    {
        Like Get(int id);
        Like Get(string Ids);
        List<Like> GetByAuthor(string Ids);
        void Add(Like entity);
        void Update(Like entity);
        void Remove(int id);
        void SaveChanges();
    }
}
