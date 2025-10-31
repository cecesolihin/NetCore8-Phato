using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.Identity.UserManagement.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetSingleGroupCommand : IRequest<ApiResponse<GroupDto>>
    {
        [JsonPropertyName("group_id")]
        public string GroupId { get; set; }
    }
}
