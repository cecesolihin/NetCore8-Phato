using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailByCriteriaCommandHandler : IRequestHandler<GetQuestionSettingDetailByCriteriaCommand, ApiResponse<QuestionSettingDetailItemDto>>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailByCriteriaCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<ApiResponse<QuestionSettingDetailItemDto>> Handle(GetQuestionSettingDetailByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingDetailService.GetQuestionSettingDetailByCriteria(request);
        }
    }
}
