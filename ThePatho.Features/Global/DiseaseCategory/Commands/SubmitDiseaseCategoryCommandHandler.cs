using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.DiseaseCategory.Service;

namespace ThePatho.Features.Global.DiseaseCategory.Commands
{
    public class SubmitDiseaseCategoryCommandHandler : IRequestHandler<SubmitDiseaseCategoryCommand, ApiResponse>
    {
        private readonly IDiseaseCategoryService Service;

        public SubmitDiseaseCategoryCommandHandler(IDiseaseCategoryService _diseasecategoryService)
        {
            Service = _diseasecategoryService;
        }

        public async Task<ApiResponse> Handle(SubmitDiseaseCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitDiseaseCategory(request);
        }
    }
}

