using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.ConfigurationExtensions
{
    public static class HttpStatusCodeExtensions
    {
        public static string ParseResponseStatus(this HttpStatusCode code)
        {
            return code switch
            {
                HttpStatusCode.OK => "S",
                HttpStatusCode.InternalServerError => "F",
                _ => "Unknown"
            };
        }

        public static string TryAppendMessage(this HttpStatusCode code, string? message)
        {
            return message ?? code.ToString();
        }
    }
}
