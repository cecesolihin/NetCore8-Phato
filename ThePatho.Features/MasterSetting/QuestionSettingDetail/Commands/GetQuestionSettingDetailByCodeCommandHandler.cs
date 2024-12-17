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
    public class GetQuestionSettingDetailByCodeCommandHandler : IRequestHandler<GetQuestionSettingDetailByCodeCommand, QuestionSettingDetailItemDto>
    {
        private readonly IQuestionSettingDetailService questionSettingDetailService;

        public GetQuestionSettingDetailByCodeCommandHandler(IQuestionSettingDetailService _questionSettingDetailService)
        {
            questionSettingDetailService = _questionSettingDetailService;
        }

        public async Task<QuestionSettingDetailItemDto> Handle(GetQuestionSettingDetailByCodeCommand request, CancellationToken cancellationToken)
        {
            var data = await questionSettingDetailService.GetQuestionSettingDetailByCode(request);

            return new QuestionSettingDetailItemDto
            {
                DataOfRecords = data.Count,
                QuestionSettingDetailList = data
            };
        }
    }
}
