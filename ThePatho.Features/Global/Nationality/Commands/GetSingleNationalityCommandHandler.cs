using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Nationality.Service;
using ThePatho.Features.Global.Nationality.DTO;

namespace ThePatho.Features.Global.Nationality.Commands
{
    public class GetSingleNationalityCommandHandler : IRequestHandler<GetSingleNationalityCommand, ApiResponse<NationalityDto>>
    {
        private readonly INationalityService Service;

        public GetSingleNationalityCommandHandler(INationalityService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<NationalityDto>> Handle(GetSingleNationalityCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleNationality(request);
        }
    }
}
