using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPI.Domain.Entities;

namespace BlogAPI.DAL.Repositories.Abstract
{
    public interface IPostsRepository
    {
        Task<IEnumerable<ExpandoObject>> GetAll();
        Task<Post> GetById(int id);
        Task<bool> Create(Post entity);
        Task<Post> Update(Post entity);
        Task<bool> Delete(int id);
    }
}
