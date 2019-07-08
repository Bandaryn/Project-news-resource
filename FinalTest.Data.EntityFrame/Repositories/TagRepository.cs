using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.EntityFrame
{
    public class TagRepository : ITagRepository
    {

        private readonly PostContext dbContext;

        public TagRepository(PostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Tag entity)
        {
            var dbSet = dbContext.Set<Tag>();
            dbSet.Add(entity);
        }

        public Tag Get(int id)
        {
            var dbSet = dbContext.Set<Tag>();
            var result = dbSet.Find(id);
            return result;
        }

        public List<Tag> GetList()
        {
            var dbSet = dbContext.Set<Tag>();

            var resultList = dbSet.ToList<Tag>();

            return resultList;
        }

        public Tag GetName(string name)
        {
            var dbSet = dbContext.Set<Tag>();
            var result = dbSet.Where(x => x.Name == name).FirstOrDefault();
            return result;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<Tag>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {

            dbContext.SaveChanges();
        }

        public void Update(Tag entity)
        {
            
        }
    }
}
