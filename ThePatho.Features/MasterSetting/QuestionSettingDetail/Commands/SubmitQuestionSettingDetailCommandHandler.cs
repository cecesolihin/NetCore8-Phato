using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class SubmitQuestionSettingDetailCommandHandler : IRequestHandler<SubmitQuestionSettingDetailCommand, ApiResponse>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public SubmitQuestionSettingDetailCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<ApiResponse> Handle(SubmitQuestionSettingDetailCommand request, CancellationToken cancellationToken)
        {
           return await questionSettingDetailService.SubmitQuestionSettingDetail(request);
        }
    }
}
