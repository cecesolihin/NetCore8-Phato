using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class DeleteAdsCategoryCommand : IRequest<bool>
    {
        [JsonPropertyName("ads_category_code")]
        public string AdsCategoryCode { get; set; }

        public DeleteAdsCategoryCommand(string adsCategoryCode)
        {
            AdsCategoryCode = adsCategoryCode;
        }
    }
}
