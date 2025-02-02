
using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class DeleteQuestionSettingCommandHandler : IRequestHandler<DeleteQuestionSettingCommand, ApiResponse>
    {
        private readonly IQuestionSettingService questionSettingService;

        public DeleteQuestionSettingCommandHandler(IQuestionSettingService _questionSettingService)
        {
            questionSettingService = _questionSettingService;
        }

        public async Task<ApiResponse> Handle(DeleteQuestionSettingCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingService.DeleteQuestionSetting(request);
        }
    }

}
