using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantSkill.Service;

namespace ThePatho.Features.Applicant.ApplicantSkill.Commands
{
    public class DeleteApplicantSkillCommandHandler : IRequestHandler<DeleteApplicantSkillCommand, bool>
    {
        private readonly IApplicantSkillService applicantSkillService;

        public DeleteApplicantSkillCommandHandler(IApplicantSkillService _applicantSkillService)
        {
            applicantSkillService = _applicantSkillService;
        }

        public async Task<bool> Handle(DeleteApplicantSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantSkillService.DeleteApplicantSkill(request);
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
