using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Service;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class GetEmployeePunishmentCommandHandler : IRequestHandler<GetEmployeePunishmentCommand, ApiResponse<EmployeePunishmentItemDto>>
    {
        private readonly IEmployeePunishmentService Service;

        public GetEmployeePunishmentCommandHandler(IEmployeePunishmentService _employeepunishmentService)
        {
            Service = _employeepunishmentService;
        }

        public async Task<ApiResponse<EmployeePunishmentItemDto>> Handle(GetEmployeePunishmentCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeePunishment(request);
        }
    }
}

