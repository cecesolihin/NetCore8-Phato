using MediatR;

namespace ThePatho.Features.MasterData.AdsCategory.Commands
{
    public class DeleteAdsCategoryCommand : IRequest<bool>
    {
        public string AdsCategoryCode { get; set; }

        public DeleteAdsCategoryCommand(string adsCategoryCode)
        {
            AdsCategoryCode = adsCategoryCode;
        }
    }
}
