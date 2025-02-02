using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.ConfigurationExtensions
{
    public class ApiResponse_old<T>
    {
        public ApiResponse_old(HttpStatusCode code, T? data = default, string? message = default, string? messageDetail = default)
        {
            Status = code.ParseResponseStatus();
            Code = (ushort)code;
            Message = code.TryAppendMessage(message);
            MessageDetail = messageDetail;
            Data = data;
        }

        public string Status { get; }
        public ushort Code { get; }
        public string Message { get; }
        public string? MessageDetail { get; }
        public T? Data { get; }
    }
}
