using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class DeleteSuperiorSubordinateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_superior_id")]
        public int EmployeeSuperiorID { get; set; }
    }
}

