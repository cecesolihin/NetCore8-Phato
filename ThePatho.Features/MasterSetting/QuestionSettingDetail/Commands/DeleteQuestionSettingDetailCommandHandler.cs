
using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class DeleteQuestionSettingDetailCommandHandler : IRequestHandler<DeleteQuestionSettingDetailCommand, ApiResponse>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public DeleteQuestionSettingDetailCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<ApiResponse> Handle(DeleteQuestionSettingDetailCommand request, CancellationToken cancellationToken)
        {
            return await questionSettingDetailService.DeleteQuestionSettingDetail(request);
            
        }
    }

}
