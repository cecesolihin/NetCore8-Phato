using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class DeleteSuperiorSubordinateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeSuperiorID")]
        public int EmployeeSuperiorID { get; set; }
    }
}

