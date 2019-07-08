using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.EntityFrame
{
    public class ProfileRepository : IProfileRepository
    {

        private readonly PostContext dbContext;

        public ProfileRepository(PostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Profil entity)
        {
            var dbSet = dbContext.Set<Profil>();
            dbSet.Add(entity);
           
        }

        public Profil Get(int id)
        {
            var dbSet = dbContext.Set<Profil>();
            var result = dbSet.Find(id);
            return result;
        }

        public Profil Get(string Ids)
        {
            var dbSet = dbContext.Set<Profil>();
            var result = dbSet.Where(x => x.Ids == Ids).FirstOrDefault();
            return result;
        }

        public List<Profil> GetList()
        {
            var dbSet = dbContext.Set<Profil>();

            var resultList = dbSet.ToList<Profil>();

            return resultList;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<Profil>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(Profil entity)
        {
            
        }
    }
}
