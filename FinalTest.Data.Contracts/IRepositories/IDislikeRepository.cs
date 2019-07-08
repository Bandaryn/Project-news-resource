using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts.IRepositories
{
    public interface IDislikeRepository
    {
        Dislike Get(int id);
        Dislike Get(string Ids);
        List<Dislike> GetByAuthor(string Ids);
        void Add(Dislike entity);
        void Update(Dislike entity);
        void Remove(int id);
        void SaveChanges();
    }
}
