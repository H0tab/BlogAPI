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
        public Task<IEnumerable<ExpandoObject>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
