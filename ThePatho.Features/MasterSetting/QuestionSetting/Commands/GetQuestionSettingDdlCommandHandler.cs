using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;
using ThePatho.Features.MasterSetting.QuestionSetting.DTO;
using ThePatho.Features.MasterSetting.QuestionSetting.Service;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands;

namespace ThePatho.Features.MasterSetting.QuestionSetting.Commands
{
    public class GetQuestionSettingDdlCommandHandler : IRequestHandler<GetQuestionSettingDdlCommand, QuestionSettingItemDto>
    {
        private readonly IQuestionSettingService questionSettingService;

        public GetQuestionSettingDdlCommandHandler(IQuestionSettingService _QuestionSetting)
        {
            questionSettingService = _QuestionSetting;
        }

        public async Task<QuestionSettingItemDto> Handle(GetQuestionSettingDdlCommand request, CancellationToken cancellationToken)
        {
            var questionSetting = await questionSettingService.GetQuestionSettingDdl(request);

            return new QuestionSettingItemDto
            {
                DataOfRecords = questionSetting.Count,
                QuestionSettingList = questionSetting
            };
        }
    }
}
