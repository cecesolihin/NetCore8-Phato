
using MediatR;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class DeleteQuestionSettingDetailCommandHandler : IRequestHandler<DeleteQuestionSettingDetailCommand, bool>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public DeleteQuestionSettingDetailCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<bool> Handle(DeleteQuestionSettingDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await questionSettingDetailService.DeleteQuestionSettingDetail(request);
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
