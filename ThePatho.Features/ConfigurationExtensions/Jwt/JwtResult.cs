using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePatho.Features.ConfigurationExtensions.Jwt
{
    public class JwtResult()
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
