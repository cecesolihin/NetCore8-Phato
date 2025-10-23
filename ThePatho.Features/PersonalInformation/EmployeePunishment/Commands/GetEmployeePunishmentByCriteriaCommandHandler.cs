using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Service;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class GetEmployeePunishmentByCriteriaCommandHandler : IRequestHandler<GetEmployeePunishmentByCriteriaCommand, ApiResponse<EmployeePunishmentItemDto>>
    {
        private readonly IEmployeePunishmentService Service;

        public GetEmployeePunishmentByCriteriaCommandHandler(IEmployeePunishmentService _employeepunishmentService)
        {
            Service = _employeepunishmentService;
        }

        public async Task<ApiResponse<EmployeePunishmentItemDto>> Handle(GetEmployeePunishmentByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeePunishmentByCriteria(request);
        }
    }
}

