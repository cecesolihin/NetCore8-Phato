using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantSkill.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class DeleteApplicantSkillCommandHandler : IRequestHandler<DeleteApplicantSkillCommand, ApiResponse>
    {
        private readonly IApplicantSkillService applicantSkillService;

        public DeleteApplicantSkillCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService = _applicantSkillService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantSkillCommand request, CancellationToken cancellationToken)
        {
            return await applicantSkillService.DeleteApplicantSkill(request);
                
        }
    }
}
