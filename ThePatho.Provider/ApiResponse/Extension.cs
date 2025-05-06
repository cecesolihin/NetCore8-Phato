
using System.Net;

namespace ThePatho.Provider.ApiResponse
{
    public static class Extension
    {
        public static string ParseResponseStatus(this HttpStatusCode httpStatusCode)
        {
            return httpStatusCode switch
            {
                >= HttpStatusCode.OK and < HttpStatusCode.Ambiguous => "Success",
                _ => "Error"
            };
        }

        public static string TryAppendMessage(this HttpStatusCode httpStatusCode, string? message)
        {
            return httpStatusCode switch
            {
                >= HttpStatusCode.OK and < HttpStatusCode.Ambiguous when string.IsNullOrWhiteSpace(message) => ResponseConstant.Success,

                >= HttpStatusCode.OK and < HttpStatusCode.Ambiguous => message!,

                >= HttpStatusCode.Ambiguous when string.IsNullOrWhiteSpace(message) => ResponseConstant.Error,

                > HttpStatusCode.Ambiguous => message!,

                _ => ResponseConstant.Error
            };
        }
    }
}
