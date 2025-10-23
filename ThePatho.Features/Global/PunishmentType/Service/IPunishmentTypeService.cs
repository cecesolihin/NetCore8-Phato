using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.PunishmentType.Commands;
using ThePatho.Features.Global.PunishmentType.DTO;

namespace ThePatho.Features.Global.PunishmentType.Service
{
    public interface IPunishmentTypeService
    {
        Task<ApiResponse<PunishmentTypeItemDto>> GetPunishmentType(GetPunishmentTypeCommand request);
        Task<ApiResponse<PunishmentTypeDto>> GetSinglePunishmentType(GetSinglePunishmentTypeCommand request);
        Task<ApiResponse<PunishmentTypeItemDto>> GetPunishmentTypeByCriteria(GetPunishmentTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitPunishmentType(SubmitPunishmentTypeCommand request);
        Task<ApiResponse> DeletePunishmentType(DeletePunishmentTypeCommand request);
    }
}
