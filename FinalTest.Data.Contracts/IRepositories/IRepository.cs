using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts
{
    public interface IRepository<T> where T:class
    {
        T Get(int id);
        T Get(string Ids);
        List<T> GetList();
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void SaveChanges();
    }
}
