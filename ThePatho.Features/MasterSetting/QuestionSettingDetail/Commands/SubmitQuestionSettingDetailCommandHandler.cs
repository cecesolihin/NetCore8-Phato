using MediatR;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class SubmitQuestionSettingDetailCommandHandler : IRequestHandler<SubmitQuestionSettingDetailCommand, string>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public SubmitQuestionSettingDetailCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<string> Handle(SubmitQuestionSettingDetailCommand request, CancellationToken cancellationToken)
        {
            await questionSettingDetailService.SubmitQuestionSettingDetail(request);
            if (request.Action == "ADD")
            {
                return "Question Setting Detail successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Question Setting Detail successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
