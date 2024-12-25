using MediatR;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailByCriteriaCommandHandler : IRequestHandler<GetQuestionSettingDetailByCriteriaCommand, QuestionSettingDetailItemDto>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailByCriteriaCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<QuestionSettingDetailItemDto> Handle(GetQuestionSettingDetailByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingDetailService.GetQuestionSettingDetailByCriteria(request);

            return new QuestionSettingDetailItemDto
            {
                DataOfRecords = data.Count,
                QuestionSettingDetailList = data
            };
        }
    }
}
