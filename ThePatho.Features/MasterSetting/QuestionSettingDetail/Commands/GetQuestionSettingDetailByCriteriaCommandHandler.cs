using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailByCriteriaCommandHandler : IRequestHandler<GetQuestionSettingDetailByCriteriaCommand, NewApiResponse<QuestionSettingDetailItemDto>>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailByCriteriaCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<NewApiResponse<QuestionSettingDetailItemDto>> Handle(GetQuestionSettingDetailByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingDetailService.GetQuestionSettingDetailByCriteria(request);
        }
    }
}
