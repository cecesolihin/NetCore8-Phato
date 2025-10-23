using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GenerateSuperiorSubordinateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("efective_date")]
        public string? EfectiveDate { get; set; }

        [JsonPropertyName("override")]
        public bool? Override { get; set; }

        [JsonPropertyName("employee_list")]
        public List<int> EmployeeList { get; set; } = new();
    }
}

