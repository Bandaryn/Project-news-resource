using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.Contracts
{
    public interface IProfileRepository
    {
        Profil Get(int id);
        Profil Get(string Ids);
        List<Profil> GetList();
        void Add(Profil entity);
        void Update(Profil entity);
        void Remove(int id);
        void SaveChanges();
    }
}
