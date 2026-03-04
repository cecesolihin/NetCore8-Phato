using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Commands
{
    public class GetSingleEmployeeFamilyCommand : IRequest<ApiResponse<EmployeeFamilyDto>>
    {
        [JsonPropertyName("EmployeeFamilyId")]
        public int EmployeeFamilyId { get; set; }

    }
}
