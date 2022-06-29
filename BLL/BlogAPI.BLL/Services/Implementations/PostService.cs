using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAPI.BLL.Services.Abstract;
using BlogAPI.DAL.Repositories.Abstract;
using BlogAPI.Domain.Entities;
using BlogAPI.Domain.Responses;
using BlogAPI.Domain.ViewModels;

namespace BlogAPI.BLL.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IPostsRepository _postRepo;

        public PostService(IPostsRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<IBaseResponse<IEnumerable<ExpandoObject>>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<Post>> GetPost(int id)
        {
            var response = new BaseResponse<Post>();

            try
            {
                var post = await _postRepo.GetById(id);
                if (post == null)
                {
                    response.Status = Status.NotFound;
                    return response;
                }

                response.Data = post;
                response.Status = Status.Ok;

                return response;
            }
            catch (Exception e)
            {
                return new BaseResponse<Post>
                {
                    Status = Status.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> CreatePost(PostViewModel entity)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var post = new Post
                {
                    Content = entity.Content,
                    Title = entity.Title,
                };

                response.Data = await _postRepo.Create(post);
                response.Status = Status.Ok;

                return response;
            }
            catch (Exception e)
            {
                return new BaseResponse<bool>
                {
                    Status = Status.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeletePost(int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var postToDelete = await _postRepo.GetById(id);
                if (postToDelete == null)
                {
                    response.Status = Status.NotFound;

                    return response;
                }

                response.Data = await _postRepo.Delete(id);
                response.Status = Status.Ok;

                return response;
            }
            catch (Exception e)
            {
                return new BaseResponse<bool>
                {
                    Status = Status.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Post>> EditPost(int id, PostViewModel entity)
        {
            var response = new BaseResponse<Post>();

            try
            {
                var postToEdit = await _postRepo.GetById(id);
                if (postToEdit == null)
                {
                    response.Status = Status.NotFound;

                    return response;
                }

                postToEdit.Content = entity.Content;
                postToEdit.Title = entity.Title;

                response.Data = await _postRepo.Update(postToEdit);
                response.Status = Status.Ok;

                return response;
            }
            catch (Exception e)
            {
                return new BaseResponse<Post>
                {
                    Status = Status.InternalServerError
                };
            }
        }
    }
}
