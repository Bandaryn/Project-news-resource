using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts
{
    public interface IPostRepository
    {
        Post Get(int id);
        Post Get(string Ids);
        List<Post> GetList();
        List<Post> Search(string request);
        void Add(Post entity);
        void Update(Post entity);
        void Remove(int id);
        void SaveChanges();
    }
}
