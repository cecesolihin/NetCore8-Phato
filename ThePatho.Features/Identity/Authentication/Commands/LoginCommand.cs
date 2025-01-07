﻿using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions.Jwt;
using ThePatho.Features.Identity.Authentication.DTO;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class LoginCommand : IRequest<JwtResult>
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("password")]
        public string? Password { get; set; }
        
    }
}