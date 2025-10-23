using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Service;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Commands
{
    public class GetSingleEmployeePunishmentCommandHandler : IRequestHandler<GetSingleEmployeePunishmentCommand, ApiResponse<EmployeePunishmentDto>>
    {
        private readonly IEmployeePunishmentService Service;

        public GetSingleEmployeePunishmentCommandHandler(IEmployeePunishmentService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<EmployeePunishmentDto>> Handle(GetSingleEmployeePunishmentCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleEmployeePunishment(request);
        }
    }
}
