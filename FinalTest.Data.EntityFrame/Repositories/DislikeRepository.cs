using FinalTest.Data.Contracts.Entities;
using FinalTest.Data.Contracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.EntityFrame.Repositories
{
    public class DislikeRepository : IDislikeRepository
    {
        private readonly PostContext dbContext;

        public DislikeRepository(PostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Dislike entity)
        {
            var dbSet = dbContext.Set<Dislike>();
            dbSet.Add(entity);

        }

        public Dislike Get(int id)
        {
            var dbSet = dbContext.Set<Dislike>();
            var result = dbSet.Find(id);
            return result;
        }

        public Dislike Get(string Ids)
        {
            var dbSet = dbContext.Set<Dislike>();
            var result = dbSet.Where(x => x.AuthorsIds == Ids).FirstOrDefault();
            return result;
        }

        public List<Dislike> GetByAuthor(string Ids)
        {
            var dbSet = dbContext.Set<Dislike>();

            var resultList = dbSet.Where(x => x.AuthorsIds == Ids).ToList();

            return resultList;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<Dislike>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(Dislike entity)
        {

        }
    }
}
