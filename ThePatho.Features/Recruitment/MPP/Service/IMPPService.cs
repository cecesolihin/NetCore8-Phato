
using ThePatho.Features.Recruitment.MPP.Commands;
using ThePatho.Features.Recruitment.MPP.DTO;

namespace ThePatho.Features.Recruitment.MPP.Service
{
    public interface IMPPService
    {
        Task<List<MPPDto>> GetMPP(GetMPPCommand request);
        Task<MPPDto> GetMPPByCriteria(GetMPPByCriteriaCommand request);
        Task<bool> SubmitMPP(SubmitMPPCommand request);
        Task<bool> DeleteMPP(DeleteMPPCommand request);
    }
}