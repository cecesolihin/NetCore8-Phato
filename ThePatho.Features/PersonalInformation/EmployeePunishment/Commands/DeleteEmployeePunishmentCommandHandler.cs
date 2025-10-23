using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Service;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class DeleteEmployeePunishmentCommandHandler : IRequestHandler<DeleteEmployeePunishmentCommand, ApiResponse>
    {
        private readonly IEmployeePunishmentService Service;

        public DeleteEmployeePunishmentCommandHandler(IEmployeePunishmentService _employeepunishmentService)
        {
            Service = _employeepunishmentService;
        }

        public async Task<ApiResponse> Handle(DeleteEmployeePunishmentCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteEmployeePunishment(request);
        }
    }
}

