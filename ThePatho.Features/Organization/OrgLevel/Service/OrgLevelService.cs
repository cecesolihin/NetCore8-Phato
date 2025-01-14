using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Execution;
using ThePatho.Domain.Constants;
using ThePatho.Features.Organization.OrgLevel.Commands;
using ThePatho.Features.Organization.OrgLevel.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Organization.OrgLevel.Service
{
    public class OrgLevelService : IOrgLevelService
    {
        private readonly DapperContext dapperContext; 

        public OrgLevelService(DapperContext _dapperContext)
        {
            dapperContext = _dapperContext;
        }

        public async Task<List<OrgLevelDto>> GetOrganizationLevel(GetOrgLevelCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.OrganizationLevel)
               .Select(
                    "org_level_code AS OrganizationLevelCode",
                    "org_level_name AS OrganizationLevelName",
                    "sort AS Jort",
                    "is_deleted AS IsDeleted",
                    "inserted_by AS InsertedBy",
                    "inserted_date AS InsertedDate",
                    "modified_by AS ModifiedBy",
                    "modified_date AS ModifiedDate"
                )
                .When(
                    !string.IsNullOrWhiteSpace(request.FilterOrgLevelCode),
                    q => q.WhereIn("org_level_code", request.FilterOrgLevelCode)
                ).When(
                    !string.IsNullOrWhiteSpace(request.FilterOrgLevelName),
                        q => q.WhereContains("org_level_name", request.FilterOrgLevelName)
                );

            query = query.OrderByRaw(
                $"{(!string.IsNullOrWhiteSpace(request.SortBy) ? request.SortBy : "inserted_by")} {(!string.IsNullOrWhiteSpace(request.OrderBy) && (request.OrderBy.ToUpper() == "ASC" || request.OrderBy.ToUpper() == "DESC") ? request.OrderBy.ToUpper() : "DESC")}"
            );

            query = query.Skip(request.PageNumber * request.PageSize).Take(request.PageSize);

            var results = await db.GetAsync<OrgLevelDto>(query);
            return results.ToList();

        }

        public async Task<OrgLevelDto> GetOrganizationLevelByCriteria(GetOrgLevelByCriteriaCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);
            var query = new Query(TableName.OrganizationLevel)
                .Select(
                        "org_level_code AS OrganizationLevelCode",
                        "org_level_name AS OrganizationLevelName",
                        "sort AS Jort",
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

            var data = await db.FirstOrDefaultAsync<OrgLevelDto>(query);
            return data;
        }
        public async Task<bool> SubmitOrganizationLevel(SubmitOrgLevelCommand request)
        {
            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            if (string.IsNullOrWhiteSpace(request.OrgLevelCode))
            {
                throw new ArgumentException("Org level code is required.");
            }


            var existsQuery = new Query(TableName.OrganizationLevel)
            .Where("org_level_code", request.OrgLevelCode)
            .SelectRaw("COUNT(1)");

            var exists = await db.ExecuteScalarAsync<int>(existsQuery);

            if (exists == 0)
            {
                var insertQuery = new Query(TableName.OrganizationLevel).AsInsert(new
                {
                    org_level_code = request.OrgLevelCode,
                    org_level_name = request.OrgLevelName,
                    sort = request.Sort,
                    is_deleted = false,
                    inserted_by = "system",
                    inserted_date = DateTime.UtcNow
                });

                var result = await db.ExecuteAsync(insertQuery);
                return result > 0;
            }
            else
            {
                var updateQuery = new Query(TableName.OrganizationLevel)
                    .Where("org_level_code", request.OrgLevelCode)
                    .AsUpdate(new
                    {
                        org_level_name = request.OrgLevelName,
                        sort = request.Sort,
                        modified_by = "system",
                        modified_date = DateTime.UtcNow
                    });

                var result = await db.ExecuteAsync(updateQuery);
                return result > 0;
            }
        }
        public async Task<bool> DeleteOrganizationLevel(DeleteOrgLevelCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.OrgLevelCode))
                throw new ArgumentException("Org Level is required.");

            using var connection = dapperContext.CreateConnection();
            var db = new QueryFactory(connection, dapperContext.Compiler);

            var deleteQuery = new Query(TableName.OrganizationLevel)
                        .Where("org_level_code", request.OrgLevelCode)
                        .AsDelete();

            var deleteResult = await db.ExecuteAsync(deleteQuery);
            return deleteResult > 0;
        }

    }
}
