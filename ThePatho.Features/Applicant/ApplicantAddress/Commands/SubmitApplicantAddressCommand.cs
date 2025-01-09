using MediatR;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class SubmitApplicantAddressCommand : IRequest<string>
    {
        public string ApplicantNo { get; set; } // Required
        public string Address { get; set; }
        public string RT { get; set; }
        public string RW { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Ownership { get; set; }
        public string CurrentAddress { get; set; }
        public string CurrentRT { get; set; }
        public string CurrentRW { get; set; }
        public string CurrentSubDistrict { get; set; }
        public string CurrentDistrict { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentProvince { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentZipCode { get; set; }
        public string CurrentOwnership { get; set; }
        public string Action { get; set; }

    }

}
