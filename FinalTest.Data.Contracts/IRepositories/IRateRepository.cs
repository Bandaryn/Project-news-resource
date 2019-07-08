using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts
{
    public interface IRateRepository
    {
        Rate Get(int id);
        IList<Rate> GetByAuthor(string Ids);
        List<Rate> GetList();
        void Add(Rate entity);
        void Update(Rate entity);
        void Remove(int id);
        void SaveChanges();
    }
}
