using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts
{
    public interface ITagRepository
    {
        Tag Get(int id);
        Tag GetName(string name);
        List<Tag> GetList();
        void Add(Tag entity);
        void Update(Tag entity);
        void Remove(int id);
        void SaveChanges();
    }
}
