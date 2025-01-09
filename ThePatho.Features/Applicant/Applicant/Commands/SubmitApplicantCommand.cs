using MediatR;
namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class SubmitApplicantCommand : IRequest<string>
    {
        public string ApplicantNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public bool Blacklisted { get; set; }
        public string BlacklistRemarks { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public bool OrmasMembership { get; set; }
        public bool IsRehire { get; set; }
        public bool HiredAsEmp { get; set; }
        public string Action { get; set; }

    }

}
