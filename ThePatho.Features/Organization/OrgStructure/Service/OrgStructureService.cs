using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Organization.OrgStructure.Service
{
    public class OrgStructureService : IOrgStructureService
    {
        private readonly DapperContext dapperContext; 

        public OrgStructureService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<OrgStructureDto>> GetOrgStructure(GetOrgStructureCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.OrgStructure)
                .Select(
                       "org_structure_id AS OrgStructureId",
                        "org_structure_code AS OrgStructureCode",
                        "org_structure_name AS OrgStructureName",
                        "parent_org_id AS ParentOrgId",
                        "org_level_code AS OrgLevelCode",
                        "status AS Status",
                        "is_deleted AS IsDeleted",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate"
                    )
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterOrgStructureCode),
                    q => q.WhereIn("org_structure_code", request.FilterOrgStructureCode)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterOrgStructureName),
                        q => q.WhereContains("org_structure_name", request.FilterOrgStructureName)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterOrgStructureName),
                        q => q.WhereContains("org_level_code", request.FilterOrgLevelCode)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<OrgStructureDto>(query);
            return results.ToList();

        }

        public async Task<OrgStructureDto> GetOrgStructureByCriteria(GetOrgStructureByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.OrgStructure)
                .Select(
                        "org_structure_id AS OrgStructureId",
                        "org_structure_code AS OrgStructureCode",
                        "org_structure_name AS OrgStructureName",
                        "parent_org_id AS ParentOrgId",
                        "org_level_code AS OrgLevelCode",
                        "status AS Status",
                        "is_deleted AS IsDeleted",
                        "inserted_by AS InsertedBy",
                        "inserted_date AS InsertedDate",
                        "modified_by AS ModifiedBy",
                        "modified_date AS ModifiedDate"
                    )
                .When(
                    !string.IsNullOrWhiteSpace(request.OrgLevelCode),
                    q => q.WhereIn("org_level_code", request.OrgLevelCode)
                );

            var data = await db.FirstOrDefaultAsync<OrgStructureDto>(query);
            return data;
        }
        public async Task<bool> SubmitOrgStructure(SubmitOrgStructureCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            if (string.IsNullOrWhiteSpace(request.OrgStructureCode))
            {
                throw new ArgumentException("Org Structure code is required.");
            }

            var existsQuery = new Query(TableName.OrgStructure)
                            .Where("org_structure_code", request.OrgStructureCode)
                            .SelectRaw("COUNT(1)");

            var exists = await db.ExecuteScalarAsync<int>(existsQuery);

            if (exists == 0)
            {
                var insertQuery = new Query(TableName.OrgStructure).AsInsert(new
                {
                    org_structure_code = request.OrgStructureCode,
                    org_structure_name = request.OrgStructureName,
                    parent_org_id = request.ParentOrgId,
                    org_level_code = request.OrgLevelCode,
                    status = request.Status,
                    is_deleted = false,
                    inserted_by = "system",
                    inserted_date = DateTime.UtcNow
                });

                return await db.ExecuteAsync(insertQuery) > 0;
            }
            else
            {
                var updateQuery = new Query(TableName.OrgStructure)
                    .Where("org_structure_code", request.OrgStructureCode)
                    .AsUpdate(new
                    {
                        org_structure_name = request.OrgStructureName,
                        parent_org_id = request.ParentOrgId,
                        org_level_code = request.OrgLevelCode,
                        status = request.Status,
                        modified_by =  "system",
                        modified_date = DateTime.UtcNow
                    });

                return await db.ExecuteAsync(updateQuery) > 0;
            }
        }
        public async Task<bool> DeleteOrgStructure(DeleteOrgStructureCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.OrgStructureCode))
                throw new ArgumentException("Org Structure Code is required.");

            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query(TableName.OrgStructure)
                        .Where("org_structure_code", request.OrgStructureCode)
                        .AsDelete();
            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }

    }
}
