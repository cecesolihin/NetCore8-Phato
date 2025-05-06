using MediatR;

using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingDdlCommandHandler : IRequestHandler<GetQuestionSettingDdlCommand, ApiResponse<QuestionSettingItemDto>>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingDdlCommandHandler(IQuestionSettingService _QuestionSetting)
        {
            questionSettingService = _QuestionSetting;
        }

        public async Task<ApiResponse<QuestionSettingItemDto>> Handle(GetQuestionSettingDdlCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingService.GetQuestionSettingDdl(request);
        }
    }
}
