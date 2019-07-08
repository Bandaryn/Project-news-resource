using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.EntityFrame.Repositories
{
    public class RateRepository: IRateRepository
    {
        private readonly PostContext dbContext;

        public RateRepository(PostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Rate entity)
        {
            var dbSet = dbContext.Set<Rate>();
            dbSet.Add(entity);

        }

        public Rate Get(int id)
        {
            var dbSet = dbContext.Set<Rate>();
            var result = dbSet.Find(id);
            return result;
        }

        public IList<Rate> GetByAuthor(string Ids)
        {
            var dbSet = dbContext.Set<Rate>();
            var result = dbSet.Where(x => x.AuthorsIds == Ids).ToList();
            return result;
        }

        public List<Rate> GetList()
        {
            var dbSet = dbContext.Set<Rate>();

            var resultList = dbSet.ToList<Rate>();

            return resultList;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<Rate>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(Rate entity)
        {

        }
    }
}

