using MediatR;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingByCriteriaCommandHandler : IRequestHandler<GetQuestionSettingByCriteriaCommand, QuestionSettingDto>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingByCriteriaCommandHandler(IQuestionSettingService _questionSettingService)
        {
            questionSettingService = _questionSettingService;
        }

        public async Task<QuestionSettingDto> Handle(GetQuestionSettingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingService.GetQuestionSettingByCriteria(request);

            return data;
        }
    }
}
