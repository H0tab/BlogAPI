using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
        public Status Status { get; set; }
    }

    public interface IBaseResponse<T>
    {
        public T Data { get; }
        public Status Status { get; }
    }

    public enum Status
    {
        Ok,
        BadRequest,
        NotFound,
        InternalServerError,
    }
}
