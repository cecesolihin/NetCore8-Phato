using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.Service;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class DeleteDiseaseCategoryCommandHandler : IRequestHandler<DeleteDiseaseCategoryCommand, ApiResponse>
    {
        private readonly IDiseaseCategoryService Service;

        public DeleteDiseaseCategoryCommandHandler(IDiseaseCategoryService _diseasecategoryService)
        {
            Service = _diseasecategoryService;
        }

        public async Task<ApiResponse> Handle(DeleteDiseaseCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteDiseaseCategory(request);
        }
    }
}

