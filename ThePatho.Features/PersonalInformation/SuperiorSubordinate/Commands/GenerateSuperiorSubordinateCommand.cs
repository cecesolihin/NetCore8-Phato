using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GenerateSuperiorSubordinateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("effective_date")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("override")]
        public bool? OverWrite { get; set; }
        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("employee_list")]
        public List<int> EmployeeList { get; set; } = new();
    }
}

