using MediatR;
using ThePatho.Features.Organization.OrgLevel.Service;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class SubmitOrgLevelCommandHandler : IRequestHandler<SubmitOrgLevelCommand, string>
    {
        private readonly IOrgLevelService orgLevelService;

        public SubmitOrgLevelCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }

        public async Task<string> Handle(SubmitOrgLevelCommand request, CancellationToken cancellationToken)
        {
            await orgLevelService.SubmitOrganizationLevel(request);
            if (request.Action == "ADD")
            {
                return "Organization Level successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Organization Level successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
