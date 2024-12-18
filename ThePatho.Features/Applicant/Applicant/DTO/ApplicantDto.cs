using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Applicant.Applicant.DTO
{
    public class ApplicantDto
    {
        public string ApplicantNo { get; set; } // applicant_no
        public string FirstName { get; set; } // first_name
        public string? MiddleName { get; set; } // middle_name
        public string? LastName { get; set; } // last_name
        public string FullName { get; set; } // full_name
        public string Gender { get; set; } // gender
        public bool Blacklisted { get; set; } // blacklisted
        public string? BlacklistRemarks { get; set; } // blacklist_remarks
        public string? BirthPlace { get; set; } // birth_place
        public DateTime BirthDate { get; set; } // birth_date
        public string? InsertedBy { get; set; } // inserted_by
        public DateTime? InsertedDate { get; set; } // inserted_date
        public string? ModifiedBy { get; set; } // modified_by
        public DateTime? ModifiedDate { get; set; } // modified_date
        public bool? OrmasMembership { get; set; } // ormas_membership
        public bool? IsRehire { get; set; } // is_rehire
        public bool? HiredAsEmp { get; set; } // hired_as_emp
    }
    public class ApplicantItemDto
    {
        public int DataOfRecords { get; set; }
        public List<ApplicantDto> ApplicantDtoList { get; set; } = new();
    }
}
