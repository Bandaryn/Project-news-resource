using FinalTest.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.EntityFrame
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly PostContext dbContext;

        public Repository(PostContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Add(T entity)
        {
            var dbSet = dbContext.Set<T>();
            dbSet.Add(entity);
            
        }

        public T Get(int id)
        {
            var dbSet = dbContext.Set<T>();
            var result = dbSet.Find(id);
            return result;
        }

        public T Get(string Ids)
        {
            var dbSet = dbContext.Set<T>();
            var result = dbSet.Find(Ids);

            return result;
        }

        public List<T> GetList()
        {
            var dbSet = dbContext.Set<T>();

            var resultList = dbSet.ToList<T>();

            return resultList;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<T>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            
        }
    }
}
