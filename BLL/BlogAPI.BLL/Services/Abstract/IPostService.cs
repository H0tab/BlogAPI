using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPI.Domain.Entities;
using BlogAPI.Domain.Responses;
using BlogAPI.Domain.ViewModels;

namespace BlogAPI.BLL.Services.Abstract
{
    public interface IPostService
    {
        Task<IBaseResponse<IEnumerable<ExpandoObject>>> GetPosts();
        Task<IBaseResponse<Post>> GetPost(int id);
        Task<IBaseResponse<bool>> CreatePost(PostViewModel entity);
        Task<IBaseResponse<bool>> DeletePost(int id);
        Task<IBaseResponse<Post>> EditPost(int id, PostViewModel entity);
    }
}
