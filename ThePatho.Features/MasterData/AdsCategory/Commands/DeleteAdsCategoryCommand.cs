using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class DeleteAdsCategoryCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("ads_category_code")]
        public string AdsCategoryCode { get; set; }

        public DeleteAdsCategoryCommand(string adsCategoryCode)
        {
            AdsCategoryCode = adsCategoryCode;
        }
    }
}
