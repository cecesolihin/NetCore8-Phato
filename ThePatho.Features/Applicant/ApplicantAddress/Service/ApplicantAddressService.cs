using Microsoft.EntityFrameworkCore;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.Applicant.ApplicantAddress.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ApplicantAddress.Service
{
    public class ApplicantAddressService : IApplicantAddressService
    {
        private readonly ApplicationDbContext _context;

        public ApplicantAddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantAddressDto>> GetAllApplicantAddressesAsync()
        {
            return await _context.ApplicantAddresses.Select(x => new ApplicantAddressDto
            {
                ApplicantNo = x.ApplicantNo,
              
            }).ToListAsync();
        }

        public Task<ApplicantAddressDto?> GetApplicantAddressByCodeAsync(string code) => throw new NotImplementedException();
        public Task<ApplicantAddressDto> AddApplicantAddressAsync(ApplicantAddressDto address) => throw new NotImplementedException();
        public Task<ApplicantAddressDto?> UpdateApplicantAddressAsync(ApplicantAddressDto address) => throw new NotImplementedException();
        public Task<bool> DeleteApplicantAddressAsync(string code) => throw new NotImplementedException();
    }
}
