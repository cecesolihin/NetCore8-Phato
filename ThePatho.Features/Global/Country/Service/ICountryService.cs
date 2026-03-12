using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Country.Commands;
using ThePatho.Features.Global.Country.DTO;

namespace ThePatho.Features.Global.Country.Service
{
    public interface ICountryService
    {
        Task<ApiResponse<CountryItemDto>> GetCountry(GetCountryCommand request);
        Task<ApiResponse<CountryDto>> GetSingleCountry(GetSingleCountryCommand request);
        Task<ApiResponse<CountryItemDto>> GetCountryByCriteria(GetCountryByCriteriaCommand request);
        Task<ApiResponse> SubmitCountry(SubmitCountryCommand request);
        Task<ApiResponse> DeleteCountry(DeleteCountryCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportCountryCommand request);
    }
}

