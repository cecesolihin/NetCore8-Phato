using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class SubmitEmployeeMedicalCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("diseaseCategoryCode")]
        public string DiseaseCategoryCode { get; set; } = null!;

        [JsonPropertyName("diseaseName")]
        public string DiseaseName { get; set; } = null!;

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; } = null!;

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; } = null!;

        [JsonPropertyName("therapy")]
        public string Therapy { get; set; } = null!;

        [JsonPropertyName("hospital")]
        public string Hospital { get; set; } = null!;

        [JsonPropertyName("countryId")]
        public string CountryId { get; set; } = null!;

        [JsonPropertyName("provinceId")]
        public string ProvinceId { get; set; } = null!;

        [JsonPropertyName("cityCode")]
        public string CityCode { get; set; } = null!;

        [JsonPropertyName("doctor")]
        public string Doctor { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = null!;

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("insertedBy")]
        public string InsertedBy { get; set; } = null!;

        [JsonPropertyName("insertedDate")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; } = null!;

        [JsonPropertyName("modifiedDate")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("timeIn")]
        public string? TimeIn { get; set; }

        [JsonPropertyName("timeOut")]
        public string? TimeOut { get; set; }

        [JsonPropertyName("obat")]
        public string Obat { get; set; } = null!;

        [JsonPropertyName("tindakanPertama")]
        public string TindakanPertama { get; set; } = null!;

        [JsonPropertyName("tindakanKedua")]
        public string TindakanKedua { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

