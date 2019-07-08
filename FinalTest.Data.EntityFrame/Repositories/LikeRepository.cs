using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.EntityFrame.Repositories
{
    public class LikeRepository: ILikeRepository
    {
        private readonly PostContext dbContext;

        public LikeRepository(PostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Like entity)
        {
            var dbSet = dbContext.Set<Like>();
            dbSet.Add(entity);

        }

        public Like Get(int id)
        {
            var dbSet = dbContext.Set<Like>();
            var result = dbSet.Find(id);
            return result;
        }

        public Like Get(string Ids)
        {
            var dbSet = dbContext.Set<Like>();
            var result = dbSet.Where(x => x.AuthorsIds == Ids).FirstOrDefault();
            return result;
        }

        public List<Like> GetByAuthor(string Ids)
        {
            var dbSet = dbContext.Set<Like>();

            var resultList = dbSet.Where(x => x.AuthorsIds == Ids).ToList();

            return resultList;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<Like>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(Like entity)
        {

        }
    }
}

