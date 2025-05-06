using Microsoft.AspNetCore.Mvc;
namespace ThePatho.Provider.ApiResponse
{
    public sealed class ApiResult<TResponse> : IActionResult where TResponse : ApiResponse
    {
        private readonly TResponse _response;

        public ApiResult(TResponse response)
        {
            _response = response;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_response)
            {
                StatusCode = _response.Code
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
