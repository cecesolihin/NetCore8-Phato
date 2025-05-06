using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailCommandHandler : IRequestHandler<GetQuestionSettingDetailCommand, ApiResponse<QuestionSettingDetailItemDto>>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<ApiResponse<QuestionSettingDetailItemDto>> Handle(GetQuestionSettingDetailCommand request, CancellationToken cancellationToken)
        {
          return await questionSettingDetailService.GetQuestionSettingDetail(request);
        }
    }
}
