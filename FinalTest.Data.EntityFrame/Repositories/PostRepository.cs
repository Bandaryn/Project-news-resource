using FinalTest.Data.Contracts;
using FinalTest.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.Data.EntityFrame.Repositories
{
    public class PostRepository:IPostRepository
    {
        private readonly PostContext dbContext;

        public PostRepository(PostContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Post entity)
        {
            var dbSet = dbContext.Set<Post>();
            dbSet.Add(entity);

        }

        public Post Get(int id)
        {
            var dbSet = dbContext.Set<Post>();
            var result = dbSet.Find(id);
            return result;
        }

        public Post Get(string Title)
        {
            var dbSet = dbContext.Set<Post>();
            var result = dbSet.Where(x => x.Title == Title).FirstOrDefault();
            return result;
        }

        public List<Post> GetList()
        {
            var dbSet = dbContext.Set<Post>();

            var resultList = dbSet.ToList<Post>();

            return resultList;
        }

        public List<Post> Search(string request)
        {
            var dbSet = dbContext.Set<Post>();

            var resultList = dbSet.Where(x => x.Title.Contains(request)).ToList<Post>();

            var listDescription = dbSet.Where(x => x.Description.Contains(request)).ToList<Post>();

            foreach(var element in listDescription)
            {
                if (!resultList.Contains(element))
                {
                    resultList.Add(element);
                }
                
            }

            return resultList;
        }

        public void Remove(int id)
        {
            var dbSet = dbContext.Set<Post>();
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Update(Post entity)
        {

        }
    }
}

