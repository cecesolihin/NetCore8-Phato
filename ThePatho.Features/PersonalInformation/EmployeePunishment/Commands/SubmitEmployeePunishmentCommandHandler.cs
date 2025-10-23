using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Service;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class SubmitEmployeePunishmentCommandHandler : IRequestHandler<SubmitEmployeePunishmentCommand, ApiResponse>
    {
        private readonly IEmployeePunishmentService Service;

        public SubmitEmployeePunishmentCommandHandler(IEmployeePunishmentService _employeepunishmentService)
        {
            Service = _employeepunishmentService;
        }

        public async Task<ApiResponse> Handle(SubmitEmployeePunishmentCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitEmployeePunishment(request);
        }
    }
}

