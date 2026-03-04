using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.SuperiorSubordinate.Commands
{
    public class GenerateSuperiorSubordinateCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("override")]
        public bool? OverWrite { get; set; }
        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("employeeList")]
        public List<int> EmployeeList { get; set; } = new();
    }
}

