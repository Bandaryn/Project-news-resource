using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.EntityFrame.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly PostContext dbContext;

        public CommentRepository(PostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Comment entity)
        {
            var dbSet = dbContext.Set<Comment>();
            dbSet.Add(entity);

        }

        public Comment Get(int id)
        {
            var dbSet = dbContext.Set<Comment>();
            var result = dbSet.Find(id);
            return result;
        }

        public Comment Get(string Ids)
        {
            var dbSet = dbContext.Set<Comment>();
            var result = dbSet.Where(x => x.Author.Ids == Ids).FirstOrDefault();
            return result;
        }

        public List<Comment> GetList()
        {
            var dbSet = dbContext.Set<Comment>();

            var resultList = dbSet.ToList<Comment>();

            return resultList;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<Comment>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(Comment entity)
        {

        }
    }
}

