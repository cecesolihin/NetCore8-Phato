using MediatR;

using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailCommandHandler : IRequestHandler<GetQuestionSettingDetailCommand, QuestionSettingDetailItemDto>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<QuestionSettingDetailItemDto> Handle(GetQuestionSettingDetailCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingDetailService.GetQuestionSettingDetail(request);

            return new QuestionSettingDetailItemDto
            {
                DataOfRecords = data.Count,
                QuestionSettingDetailList = data
            };
        }
    }
}
