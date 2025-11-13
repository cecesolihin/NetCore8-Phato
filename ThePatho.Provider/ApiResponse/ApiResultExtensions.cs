using System.Net;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Provider.ApiResponse
{
    public static class ApiResultExtensions
    {
        public static ApiResult<T> Success<T>(T response) where T : ApiResponse
        {
            return new ApiResult<T>(response);
        }

        public static ApiResult<T> Failure<T>(string message, string? messageDetail = null) where T : ApiResponse, new()
        {
            var response = new T();
            response.GetType().GetProperty("MessageDetail")?.SetValue(response, messageDetail ?? message);
            return new ApiResult<T>(response);
        }
    }
}