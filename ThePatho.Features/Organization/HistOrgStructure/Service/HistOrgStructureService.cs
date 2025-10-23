using SqlKata;
using SqlKata.Execution;
using System.Net;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.HistOrgStructure.Commands;
using ThePatho.Features.Organization.HistOrgStructure.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.HistOrgStructure.Service
{
    public class HistOrgStructureService : IHistOrgStructureService
    {
        #region [FIELDS & CTOR]
        private readonly DapperContext dapperContext;

        public HistOrgStructureService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }
        #endregion

        #region [METHODS]
        public async Task<ApiResponse<HistOrgStructureItemDto>> GetHistOrgStructure(GetHistOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.HistOrgStructure)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.Status),
                        q => q.Where("Status", request.Status)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureCode),
                        q => q.WhereContains("OrgStructureCode", request.OrgStructureCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureName),
                        q => q.WhereContains("OrgStructureName", request.OrgStructureName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.Status),
                        q => q.Where("Status", request.Status)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.CompanyCode),
                        q => q.WhereContains("CompanyCode", request.CompanyCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.CostCenterCode),
                        q => q.WhereContains("CostCenterCode", request.CostCenterCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.Location),
                        q => q.WhereContains("Location", request.Location)
                    );

                query = query.OrderByRaw(
                    $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "InsertedBy")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
                );

                query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

                var data = await db.GetAsync<HistOrgStructureDto>(query);

                var result = new HistOrgStructureItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    HistOrgStructureList = data.ToList(),
                };
                return new ApiResponse<HistOrgStructureItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<HistOrgStructureItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<HistOrgStructureItemDto>> GetHistOrgStructureByCriteria(GetHistOrgStructureByCriteriaCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.HistOrgStructure)
                    .Select("*")
                    .When(
                        !string.IsNullOrWhiteSpace(request.Status),
                        q => q.Where("Status", request.Status)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureCode),
                        q => q.WhereContains("OrgStructureCode", request.OrgStructureCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.OrgStructureName),
                        q => q.WhereContains("OrgStructureName", request.OrgStructureName)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.Status),
                        q => q.Where("Status", request.Status)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.CompanyCode),
                        q => q.WhereContains("CompanyCode", request.CompanyCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.CostCenterCode),
                        q => q.WhereContains("CostCenterCode", request.CostCenterCode)
                    )
                    .When(
                        !string.IsNullOrWhiteSpace(request.Location),
                        q => q.WhereContains("Location", request.Location)
                    );

                var data = await db.GetAsync<HistOrgStructureDto>(query);

                var result = new HistOrgStructureItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    HistOrgStructureList = data.ToList(),
                };
                return new ApiResponse<HistOrgStructureItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<HistOrgStructureItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        public async Task<ApiResponse> SubmitHistOrgStructure(SubmitHistOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var ArgumentException = new List<string>();

                // Validasi field NOT NULL berdasarkan struktur tabel
                if (request.OrgStructureId <= 0)
                    ArgumentException.Add("OrgStructure ID is required and must be greater than 0.");

                if (string.IsNullOrWhiteSpace(request.OrgStructureCode))
                    ArgumentException.Add("OrgStructure Code is required.");

                if (string.IsNullOrWhiteSpace(request.OrgStructureName))
                    ArgumentException.Add("OrgStructure Name is required.");

                if (string.IsNullOrWhiteSpace(request.OrgLevelCode))
                    ArgumentException.Add("OrgLevel Code is required.");

                if (string.IsNullOrWhiteSpace(request.Status))
                    ArgumentException.Add("Status is required.");

                if (string.IsNullOrWhiteSpace(request.CompanyCode))
                    ArgumentException.Add("Company Code is required.");

                // Validasi panjang field sesuai constraint di database
                if (request.OrgStructureCode.Length > 50)
                    ArgumentException.Add("OrgStructure Code cannot exceed 50 characters.");

                if (request.OrgStructureName.Length > 255)
                    ArgumentException.Add("OrgStructure Name cannot exceed 255 characters.");

                if (request.OrgLevelCode.Length > 50)
                    ArgumentException.Add("OrgLevel Code cannot exceed 50 characters.");

                if (request.Status.Length > 1)
                    ArgumentException.Add("Status must be 1 character.");

                if (!string.IsNullOrWhiteSpace(request.CostCenterCode) && request.CostCenterCode.Length > 50)
                    ArgumentException.Add("CostCenter Code cannot exceed 50 characters.");

                if (!string.IsNullOrWhiteSpace(request.Phone) && request.Phone.Length > 50)
                    ArgumentException.Add("Phone cannot exceed 50 characters.");

                if (!string.IsNullOrWhiteSpace(request.PhoneExt) && request.PhoneExt.Length > 10)
                    ArgumentException.Add("Phone Extension cannot exceed 10 characters.");

                if (request.CompanyCode.Length > 128)
                    ArgumentException.Add("Company Code cannot exceed 128 characters.");

                if (!string.IsNullOrWhiteSpace(request.Path) && request.Path.Length > 200)
                    ArgumentException.Add("Path cannot exceed 200 characters.");

                if (!string.IsNullOrWhiteSpace(request.Function) && request.Function.Length > 255)
                    ArgumentException.Add("Function cannot exceed 255 characters.");

                // Validasi Sort (tinyint range: 0-255)
                if (request.Sort < 0 || request.Sort > 255)
                    ArgumentException.Add("Sort must be between 0 and 255.");

                // Validasi tanggal
                if (!string.IsNullOrWhiteSpace(request.StartDate) && !DateTime.TryParse(request.StartDate, out _))
                    ArgumentException.Add("Start Date must be a valid date.");

                if (!string.IsNullOrWhiteSpace(request.EndDate) && !DateTime.TryParse(request.EndDate, out _))
                    ArgumentException.Add("End Date must be a valid date.");

                if (ArgumentException.Any())
                {
                    return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", string.Join(", ", ArgumentException.ToArray()));
                }

                // Untuk insert/update, kita gunakan HistOrgStructureId
                if (request.HistOrgStructureId == 0)
                {
                    // Insert
                    var insertQuery = new Query(TableOrganization.HistOrgStructure).AsInsert(new
                    {
                        OrgStructureId = request.OrgStructureId,
                        OrgStructureCode = request.OrgStructureCode,
                        OrgStructureName = request.OrgStructureName,
                        ParentOrgStructureId = request.ParentOrgStructureId,
                        OrgLevelCode = request.OrgLevelCode,
                        Status = request.Status,
                        CostCenterCode = request.CostCenterCode,
                        Location = request.Location,
                        Phone = request.Phone,
                        PhoneExt = request.PhoneExt,
                        Sort = request.Sort,
                        CompanyCode = request.CompanyCode,
                        StartDate = !string.IsNullOrWhiteSpace(request.StartDate) ? DateTime.Parse(request.StartDate) : (DateTime?)null,
                        EndDate = !string.IsNullOrWhiteSpace(request.EndDate) ? DateTime.Parse(request.EndDate) : (DateTime?)null,
                        IsDeleted = request.IsDeleted,
                        Path = request.Path,
                        Function = request.Function,
                        InsertedBy = "system",
                        InsertedDate = DateTime.UtcNow
                    });

                    var insertResult = await db.ExecuteAsync(insertQuery);
                }
                else
                {
                    // Update - cek apakah data exists
                    var existsQuery = new Query(TableOrganization.HistOrgStructure)
                        .Where("HistOrgStructureID", request.HistOrgStructureId)
                        .SelectRaw("COUNT(1)");

                    var exists = await db.ExecuteScalarAsync<int>(existsQuery);

                    if (exists == 0)
                    {
                        return new ApiResponse(HttpStatusCode.NotFound, $"HistOrgStructure with ID {request.HistOrgStructureId} not found.");
                    }

                    // Update
                    var updateQuery = new Query(TableOrganization.HistOrgStructure)
                        .Where("HistOrgStructureID", request.HistOrgStructureId)
                        .AsUpdate(new
                        {
                            OrgStructureId = request.OrgStructureId,
                            OrgStructureCode = request.OrgStructureCode,
                            OrgStructureName = request.OrgStructureName,
                            ParentOrgStructureId = request.ParentOrgStructureId,
                            OrgLevelCode = request.OrgLevelCode,
                            Status = request.Status,
                            CostCenterCode = request.CostCenterCode,
                            Location = request.Location,
                            Phone = request.Phone,
                            PhoneExt = request.PhoneExt,
                            Sort = request.Sort,
                            CompanyCode = request.CompanyCode,
                            StartDate = !string.IsNullOrWhiteSpace(request.StartDate) ? DateTime.Parse(request.StartDate) : (DateTime?)null,
                            EndDate = !string.IsNullOrWhiteSpace(request.EndDate) ? DateTime.Parse(request.EndDate) : (DateTime?)null,
                            IsDeleted = request.IsDeleted,
                            Path = request.Path,
                            Function = request.Function,
                            ModifiedBy = "system",
                            ModifiedDate = DateTime.UtcNow
                        });

                    var updateResult = await db.ExecuteAsync(updateQuery);
                }
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} HistOrgStructure successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} HistOrgStructure", ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteHistOrgStructure(DeleteHistOrgStructureCommand request)
        {
            try
            {
                if (request.HistOrgStructureId  == 0)
                {
                    return new ApiResponse<HistOrgStructureDto>(
                         HttpStatusCode.BadRequest,
                         "HistOrgStructure is required"
                     );
                }

                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);

                var deleteQuery = new Query(TableOrganization.HistOrgStructure)
                                .Where("HistOrgStructureId", request.HistOrgStructureId)
                                .AsDelete();

                var deleteResult = await db.ExecuteAsync(deleteQuery);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete ", ex.Message.ToString());
            }

        }

        public async Task<ApiResponse<HistOrgStructureDto>> GetSingleHistOrgStructure(GetSingleHistOrgStructureCommand request)
        {
            try
            {
                using var connection = dapperContext.CreateConnection();
                var db = new QueryFactory(connection, dapperContext.Compiler);
                var query = new Query(TableOrganization.HistOrgStructure)
                    .Select("*")
                    .Where("HistOrgStructureId", request.HistOrgStructureId);

                var data = await db.FirstOrDefaultAsync<HistOrgStructureDto>(query);

                if (data == null)
                {
                    return new ApiResponse<HistOrgStructureDto>(
                         HttpStatusCode.NotFound,
                         "data not found"
                     );
                }
                return new ApiResponse<HistOrgStructureDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<HistOrgStructureDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }
        #endregion
    }
}
