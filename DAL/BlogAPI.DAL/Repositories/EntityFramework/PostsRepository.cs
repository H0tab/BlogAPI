using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPI.DAL.Repositories.Abstract;
using BlogAPI.Domain.Entities;

namespace BlogAPI.DAL.Repositories.EntityFramework
{
    public class PostsRepository : IPostsRepository
    {
        private readonly AppDbContext _dbContext;

        public PostsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<ExpandoObject>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetById(int id)
        {
            return await _dbContext.Posts.FindAsync(id);
        }

        public async Task<bool> Create(Post entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Post> Update(Post entity)
        {
            _dbContext.Posts.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entityToDelete = await _dbContext.Posts.FindAsync(id);

            if (entityToDelete != null)
            {
                _dbContext.Remove(entityToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
