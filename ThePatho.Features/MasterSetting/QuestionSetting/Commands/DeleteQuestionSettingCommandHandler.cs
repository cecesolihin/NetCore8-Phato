
using MediatR;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class DeleteQuestionSettingCommandHandler : IRequestHandler<DeleteQuestionSettingCommand, bool>
    {
        private readonly IQuestionSettingService questionSettingService;

        public DeleteQuestionSettingCommandHandler(IQuestionSettingService _questionSettingService)
        {
            questionSettingService = _questionSettingService;
        }

        public async Task<bool> Handle(DeleteQuestionSettingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await questionSettingService.DeleteQuestionSetting(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }

}
