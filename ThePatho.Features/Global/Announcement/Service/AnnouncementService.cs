using Dapper;
using System.Data;
using System.Data.Common;
using System.Net;
using ThePatho.Features.Global.Announcement.Commands;
using ThePatho.Features.Global.Announcement.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Announcement.Service
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        public AnnouncementService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
        }

        public async Task<ApiResponse<AnnouncementItemDto>> GetAnnouncement(GetAnnouncementCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@AnnounceSubject", request.FilterAnnounceSubject ?? string.Empty);
                parameters.Add("@AnnounceContent", request.FilterAnnounceContent ?? string.Empty);
                parameters.Add("@Status", request.FilterStatus);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Announcement/Sql/get_announcement");
                var data = await dbConnection.QueryAsync<AnnouncementDto>(query, parameters);
                var result = new AnnouncementItemDto
                {
                    DataOfRecords = data.Count(),
                    AnnouncementList = data.ToList(),
                };
                return new ApiResponse<AnnouncementItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<AnnouncementItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<AnnouncementDto>> GetSingleAnnouncement(GetSingleAnnouncementCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AnnouncementId", request.FilterAnnouncementId);

                var query = await queryLoader.LoadQueryAsync("Global/Announcement/Sql/get_single_announcement");

                var data = await dbConnection.QueryFirstOrDefaultAsync<AnnouncementDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<AnnouncementDto>(HttpStatusCode.NotFound, $"Data not Found", "Data not Found");
                }
                return new ApiResponse<AnnouncementDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<AnnouncementDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<AnnouncementItemDto>> GetAnnouncementByCriteria(GetAnnouncementByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AnnounceSubject", request.FilterAnnounceSubject ?? string.Empty);
                parameters.Add("@Status", request.FilterStatus);


                var query = await queryLoader.LoadQueryAsync("Global/Announcement/Sql/get_criteria_announcement");
                var data = await dbConnection.QueryAsync<AnnouncementDto>(query, parameters);
                var result = new AnnouncementItemDto
                {
                    DataOfRecords = data.Count(),
                    AnnouncementList = data.ToList(),
                };
                return new ApiResponse<AnnouncementItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<AnnouncementItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitAnnouncement(SubmitAnnouncementCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AnnouncementId", request.AnnouncementId);
                parameters.Add("@AnnounceSubject", request.AnnounceSubject);
                parameters.Add("@AnnounceImage", request.AnnounceImage);
                parameters.Add("@Attachment", request.Attachment);
                parameters.Add("@AnnounceContent", request.AnnounceContent);
                parameters.Add("@Status", request.Status);
                parameters.Add("@ActiveStatus", request.ActiveStatus);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", "admin");

                var query = await queryLoader.LoadQueryAsync("Global/Announcement/Sql/submit_announcement");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.AnnounceSubject} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.AnnounceSubject}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteAnnouncement(DeleteAnnouncementCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AnnouncementId", request.AnnouncementId);
                var query_single = await queryLoader.LoadQueryAsync("Global/Announcement/Sql/get_single_announcement");

                var data_single = await dbConnection.QueryFirstOrDefaultAsync<AnnouncementDto>(query_single, parameters);
                if (data_single == null) 
                {
                    return new ApiResponse(HttpStatusCode.NotFound, $"Failed to delete", "Data not Found");
                }

                var query = await queryLoader.LoadQueryAsync("Global/Announcement/Sql/delete_announcement");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }

    }
}
