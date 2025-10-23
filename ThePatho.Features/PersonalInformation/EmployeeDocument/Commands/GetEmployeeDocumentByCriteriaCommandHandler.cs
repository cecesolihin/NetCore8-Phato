using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeDocument.Service;
using ThePatho.Features.PersonalInformation.EmployeeDocument.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeDocument.Commands
{
    public class GetEmployeeDocumentByCriteriaCommandHandler : IRequestHandler<GetEmployeeDocumentByCriteriaCommand, ApiResponse<EmployeeDocumentItemDto>>
    {
        private readonly IEmployeeDocumentService Service;

        public GetEmployeeDocumentByCriteriaCommandHandler(IEmployeeDocumentService _employeedocumentService)
        {
            Service = _employeedocumentService;
        }

        public async Task<ApiResponse<EmployeeDocumentItemDto>> Handle(GetEmployeeDocumentByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetEmployeeDocumentByCriteria(request);
        }
    }
}

