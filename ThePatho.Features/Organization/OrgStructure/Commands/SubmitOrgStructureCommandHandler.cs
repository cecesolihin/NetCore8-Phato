using MediatR;
using ThePatho.Features.Organization.OrgStructure.Service;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class SubmitOrgStructureCommandHandler : IRequestHandler<SubmitOrgStructureCommand, string>
    {
        private readonly IOrgStructureService orgStructureService;

        public SubmitOrgStructureCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }

        public async Task<string> Handle(SubmitOrgStructureCommand request, CancellationToken cancellationToken)
        {
            await orgStructureService.SubmitOrgStructure(request);
            if (request.Action == "ADD")
            {
                return "Organization Structure successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Organization Structure successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
