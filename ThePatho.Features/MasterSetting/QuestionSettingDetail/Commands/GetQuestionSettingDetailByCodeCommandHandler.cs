using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailByCodeCommandHandler : IRequestHandler<GetQuestionSettingDetailByCodeCommand, QuestionSettingDetailDto>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailByCodeCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<QuestionSettingDetailDto> Handle(GetQuestionSettingDetailByCodeCommand request, CancellationToken cancellationToken)
        {
            var questionSettingDetail = await questionSettingDetailService.GetQuestionSettingDetailByCode(request);

            return questionSettingDetail;
        }
    }
}
