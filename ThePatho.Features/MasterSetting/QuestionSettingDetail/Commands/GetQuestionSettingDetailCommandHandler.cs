using MediatR;

using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailCommandHandler : IRequestHandler<GetQuestionSettingDetailCommand, QuestionSettingDetailItemDto>
    {
        private readonly IQuestionSettingDetailService QuestionSettingDetailService;

        public GetQuestionSettingDetailCommandHandler(IQuestionSettingDetailService _QuestionSettingDetailService)
        {
            QuestionSettingDetailService = _QuestionSettingDetailService;
        }

        public async Task<QuestionSettingDetailItemDto> Handle(GetQuestionSettingDetailCommand request, CancellationToken cancellationToken)
        {
            var QuestionSettingDetails = await QuestionSettingDetailService.GetQuestionSettingDetail(request);

            return new QuestionSettingDetailItemDto
            {
                DataOfRecords = QuestionSettingDetails.Count,
                QuestionSettingDetailList = QuestionSettingDetails
            };
        }
    }
}
