using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class SubmitApplicantAddressCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; } // Required

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("rt")]
        public string RT { get; set; }

        [JsonPropertyName("rw")]
        public string RW { get; set; }

        [JsonPropertyName("sub_district")]
        public string SubDistrict { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }

        [JsonPropertyName("ownership")]
        public string Ownership { get; set; }

        [JsonPropertyName("current_address")]
        public string CurrentAddress { get; set; }

        [JsonPropertyName("current_rt")]
        public string CurrentRT { get; set; }

        [JsonPropertyName("current_rw")]
        public string CurrentRW { get; set; }

        [JsonPropertyName("current_sub_district")]
        public string CurrentSubDistrict { get; set; }

        [JsonPropertyName("current_district")]
        public string CurrentDistrict { get; set; }

        [JsonPropertyName("current_city")]
        public string CurrentCity { get; set; }

        [JsonPropertyName("current_province")]
        public string CurrentProvince { get; set; }

        [JsonPropertyName("current_country")]
        public string CurrentCountry { get; set; }

        [JsonPropertyName("current_zip_code")]
        public string CurrentZipCode { get; set; }

        [JsonPropertyName("current_ownership")]
        public string CurrentOwnership { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }
    }


}
