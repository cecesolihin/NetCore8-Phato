using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingByCodeCommandHandler : IRequestHandler<GetQuestionSettingByCodeCommand, QuestionSettingDto>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingByCodeCommandHandler(IQuestionSettingService _questionSettingService)
        {
            questionSettingService = _questionSettingService;
        }

        public async Task<QuestionSettingDto> Handle(GetQuestionSettingByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingService.GetQuestionSettingByCode(request);

            return data;
        }
    }
}
