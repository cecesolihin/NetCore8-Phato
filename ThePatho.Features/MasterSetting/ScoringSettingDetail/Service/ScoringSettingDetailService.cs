using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.Commands;
using ThePatho.Features.MasterSetting.ScoringSettingDetail.DTO;
using ThePatho.Features.Organization.JobLevel.DTO;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.MasterSetting.ScoringSettingDetail.Service
{
    public class ScoringSettingDetailService : IScoringSettingDetailService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext; 
        private readonly ApplicationDbContext context;
        public ScoringSettingDetailService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<NewApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetail(GetScoringSettingDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);
                parameters.Add("@ScoringName", request.FilterScoringName ?? (object)DBNull.Value);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail");
                var data = await dbConnection.QueryAsync<ScoringSettingDetailDto>(query, parameters);
                var result = new ScoringSettingDetailItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ScoringSettingDetailList = data.ToList(),
                };
                return new NewApiResponse<ScoringSettingDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new NewApiResponse<ScoringSettingDetailItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<NewApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetailByCriteria(GetScoringSettingDetailByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail_by_code");

                var data = await dbConnection.QueryAsync<ScoringSettingDetailDto>(query, parameters);

                var result = new ScoringSettingDetailItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ScoringSettingDetailList = data.ToList(),
                };
                return new NewApiResponse<ScoringSettingDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new NewApiResponse<ScoringSettingDetailItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }

        }

        public async Task<NewApiResponse<ScoringSettingDetailItemDto>> GetScoringSettingDetailDdl(GetScoringSettingDetailDdlCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@ScoringCode", request.FilterScoringCode ?? (object)DBNull.Value);

                var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/search_scoring_setting_detail_ddl");
                var data = await dbConnection.QueryAsync<ScoringSettingDetailDto>(query, parameters);
                var result = new ScoringSettingDetailItemDto
                {
                    DataOfRecords = data.ToList().Count,
                    ScoringSettingDetailList = data.ToList(),
                };
                return new NewApiResponse<ScoringSettingDetailItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new NewApiResponse<ScoringSettingDetailItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitScoringSettingDetail(SubmitScoringSettingDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ScoringCode", request.ScoringCode);
                parameters.Add("@Value", request.Value);
                parameters.Add("@Character", request.Character);
                parameters.Add("@Attachment", request.Attachment);
                parameters.Add("@TextValue", request.TextValue);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/submit_scoring_setting_detail");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.ScoringCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.ScoringCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteScoringSettingDetail(DeleteScoringSettingDetailCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ScoringCode", request.ScoringCode);
                parameters.Add("@Character", request.Character);

                var query = await queryLoader.LoadQueryAsync("MasterSetting/ScoringSettingDetail/Sql/delete_scoring_setting_detail");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete {request.ScoringCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete {request.ScoringCode}", ex.Message.ToString());
            }

        }

    }
}
