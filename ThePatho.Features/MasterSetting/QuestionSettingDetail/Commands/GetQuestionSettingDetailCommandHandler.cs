using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailCommandHandler : IRequestHandler<GetQuestionSettingDetailCommand, NewApiResponse<QuestionSettingDetailItemDto>>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<NewApiResponse<QuestionSettingDetailItemDto>> Handle(GetQuestionSettingDetailCommand request, CancellationToken cancellationToken)
        {
          return await questionSettingDetailService.GetQuestionSettingDetail(request);
        }
    }
}
