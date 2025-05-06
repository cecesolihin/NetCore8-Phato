using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailDdlCommandHandler : IRequestHandler<GetQuestionSettingDetailDdlCommand, ApiResponse<QuestionSettingDetailItemDto>>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailDdlCommandHandler(IQuestionSettingDetailService _QuestionSettingDetail)
        {
            questionSettingDetailService = _QuestionSettingDetail;
        }

        public async Task<ApiResponse<QuestionSettingDetailItemDto>> Handle(GetQuestionSettingDetailDdlCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingDetailService.GetQuestionSettingDetailDdl(request);

        }
    }
}
