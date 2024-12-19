using MediatR;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailDdlCommandHandler : IRequestHandler<GetQuestionSettingDetailDdlCommand, QuestionSettingDetailItemDto>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailDdlCommandHandler(IQuestionSettingDetailService _QuestionSettingDetail)
        {
            questionSettingDetailService = _QuestionSettingDetail;
        }

        public async Task<QuestionSettingDetailItemDto> Handle(GetQuestionSettingDetailDdlCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingDetailService.GetQuestionSettingDetailDdl(request);

            return new QuestionSettingDetailItemDto
            {
                DataOfRecords = data.Count,
                QuestionSettingDetailList = data
            };
        }
    }
}
