using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.RewardType.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RewardType.Commands.Handlers
{
    public class ExportRewardTypeCommandHandler : IRequestHandler<ExportRewardTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IRewardTypeService _service;
        public ExportRewardTypeCommandHandler(IRewardTypeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportRewardTypeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
