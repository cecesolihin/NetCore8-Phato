using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePatho.Features.MasterData.AdsCategory.Commands;
using ThePatho.Features.MasterData.JobCategory.DTO;
using ThePatho.Features.MasterData.JobCategory.Service;
using ThePatho.Features.MasterSetting.QuestionSetting.Commands;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.DTO;
using ThePatho.Features.MasterSetting.QuestionSettingDetail.Service;

namespace ThePatho.Features.MasterSetting.QuestionSettingDetail.Commands
{
    public class GetQuestionSettingDetailDdlCommandHandler : IRequestHandler<GetQuestionSettingDetailDdlCommand, QuestionSettingDetailItemDto>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailDdlCommandHandler(IQuestionSettingDetailService _QuestionSettingDetail)
        {
            questionSettingDetailService = _QuestionSettingDetail;
        }

        public async Task<QuestionSettingDetailItemDto> Handle(GetQuestionSettingDetailDdlCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingDetailService.GetQuestionSettingDetailDdl(request);

            return new QuestionSettingDetailItemDto
            {
                DataOfRecords = data.Count,
                QuestionSettingDetailList = data
            };
        }
    }
}
