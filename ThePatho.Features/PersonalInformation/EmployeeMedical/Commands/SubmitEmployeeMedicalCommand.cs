using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Commands
{
    public class SubmitEmployeeMedicalCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("employee_id")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("disease_category_code")]
        public string DiseaseCategoryCode { get; set; } = null!;

        [JsonPropertyName("disease_name")]
        public string DiseaseName { get; set; } = null!;

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = null!;

        [JsonPropertyName("end_date")]
        public string EndDate { get; set; } = null!;

        [JsonPropertyName("therapy")]
        public string Therapy { get; set; } = null!;

        [JsonPropertyName("hospital")]
        public string Hospital { get; set; } = null!;

        [JsonPropertyName("country_id")]
        public string CountryId { get; set; } = null!;

        [JsonPropertyName("province_id")]
        public string ProvinceId { get; set; } = null!;

        [JsonPropertyName("city_code")]
        public string CityCode { get; set; } = null!;

        [JsonPropertyName("doctor")]
        public string Doctor { get; set; } = null!;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = null!;

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = null!;

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("inserted_by")]
        public string InsertedBy { get; set; } = null!;

        [JsonPropertyName("inserted_date")]
        public string? InsertedDate { get; set; }

        [JsonPropertyName("modified_by")]
        public string ModifiedBy { get; set; } = null!;

        [JsonPropertyName("modified_date")]
        public string? ModifiedDate { get; set; }

        [JsonPropertyName("time_in")]
        public string? TimeIn { get; set; }

        [JsonPropertyName("time_out")]
        public string? TimeOut { get; set; }

        [JsonPropertyName("obat")]
        public string Obat { get; set; } = null!;

        [JsonPropertyName("tindakan_pertama")]
        public string TindakanPertama { get; set; } = null!;

        [JsonPropertyName("tindakan_kedua")]
        public string TindakanKedua { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

