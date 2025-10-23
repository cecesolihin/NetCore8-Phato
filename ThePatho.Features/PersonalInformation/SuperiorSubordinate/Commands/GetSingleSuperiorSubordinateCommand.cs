using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.SuperiorSubordinate.DTO;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GetSingleSuperiorSubordinateCommand : IRequest<ApiResponse<SuperiorSubordinateDto>>
    {
        [JsonPropertyName("filter_EmployeeSuperiorID")]
        public int EmployeeSuperiorID { get; set; }

    }
}
