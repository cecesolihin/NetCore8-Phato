using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingByCriteriaCommandHandler : IRequestHandler<GetQuestionSettingByCriteriaCommand, NewApiResponse<QuestionSettingDto>>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingByCriteriaCommandHandler(IQuestionSettingService _questionSettingService)
        {
            questionSettingService = _questionSettingService;
        }

        public async Task<NewApiResponse<QuestionSettingDto>> Handle(GetQuestionSettingByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingService.GetQuestionSettingByCriteria(request);
        }
    }
}
