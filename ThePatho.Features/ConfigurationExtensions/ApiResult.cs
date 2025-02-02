using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.ConfigurationExtensions
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
