using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ThePatho.Features.MasterData.AdsMedia.DTO;
using ThePatho.Features.MasterData.AdsMedia.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterData.AdsMedia.Service
{
    public class AdsMediaService : IAdsMediaService
    {
        private readonly ApplicationDbContext _context;

        public AdsMediaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AdsMediaDto>> GetAllAdsMediaAsync()
        {
            var adsMediaDtoList = new List<AdsMediaDto>();
            var data = await _context.AdsMedias.ToListAsync();
            foreach (var adsMedia in data)
            {
                adsMediaDtoList.Add(new AdsMediaDto
                {
                    AdsCode = adsMedia.AdsCode,
                    AdsName = adsMedia.AdsName,
                    AdsCategoryCode = adsMedia.AdsCategoryCode,
                    Phone = adsMedia.Phone,
                    ContactPerson = adsMedia.ContactPerson,
                    Remarks = adsMedia.Remarks,
                    UseRecruitmentFee = adsMedia.UseRecruitmentFee,
                    RecruitmentFee = adsMedia.RecruitmentFee,
                    RecruitmentFee2 = adsMedia.RecruitmentFee2,
                    RecruitmentFee3 = adsMedia.RecruitmentFee3,
                    InsertedBy = adsMedia.InsertedBy,
                    InsertedDate = adsMedia.InsertedDate,
                    ModifiedBy = adsMedia.ModifiedBy,
                    ModifiedDate = adsMedia.ModifiedDate,
                });
            }
            return adsMediaDtoList;
        }

        public async Task<AdsMediaDto?> GetAdsMediaByCodeAsync(string adsMediaCode)
        {
            var adsMedia = await _context.AdsMedias
                .FirstOrDefaultAsync(a => a.AdsCode == adsMediaCode);

            if (adsMedia == null)
                return null;

            return new AdsMediaDto
            {
                AdsCode = adsMedia.AdsCode,
                AdsName = adsMedia.AdsName,
                AdsCategoryCode = adsMedia.AdsCategoryCode,
                Phone = adsMedia.Phone,
                ContactPerson = adsMedia.ContactPerson,
                Remarks = adsMedia.Remarks,
                UseRecruitmentFee = adsMedia.UseRecruitmentFee,
                RecruitmentFee = adsMedia.RecruitmentFee,
                RecruitmentFee2 = adsMedia.RecruitmentFee2,
                RecruitmentFee3 = adsMedia.RecruitmentFee3,
                InsertedBy = adsMedia.InsertedBy,
                InsertedDate = adsMedia.InsertedDate,
                ModifiedBy = adsMedia.ModifiedBy,
                ModifiedDate = adsMedia.ModifiedDate,
            };
        }

        public async Task<AdsMediaDto> AddAdsMediaAsync(AdsMediaDto adsMediaDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AdsMediaDto?> UpdateAdsMediaAsync(AdsMediaDto adsMediaDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAdsMediaAsync(string adsMediaCode)
        {
            throw new NotImplementedException();
        }
    }
}
