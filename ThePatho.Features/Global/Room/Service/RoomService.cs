using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.Global.Room.Commands;
using ThePatho.Features.Global.Room.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;

namespace ThePatho.Features.Global.Room.Service
{
    public class RoomService : IRoomService
    {
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dappercontext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        public RoomService(ApplicationDbContext _context, DapperContext _dappercontext, SqlQueryLoader _queryLoader, IDbConnection _dbConnection, ICurrentUserService _currentUserService)
        {
            context = _context;
            dappercontext = _dappercontext;
            queryLoader = _queryLoader;
            dbConnection = _dbConnection;
            currentUserService = _currentUserService;
        }

        public async Task<ApiResponse<RoomItemDto>> GetRoom(GetRoomCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PageNumber", request.PageNumber);
                parameters.Add("@PageSize", request.PageSize);
                parameters.Add("@RoomCode", request.FilterRoomCode ?? string.Empty);
                parameters.Add("@RoomName", request.FilterRoomName ?? string.Empty);
                parameters.Add("@BuildingCode", request.FilterBuildingCode ?? string.Empty);
                parameters.Add("@SortBy", request.SortBy);
                parameters.Add("@OrderBy", request.OrderBy);

                var query = await queryLoader.LoadQueryAsync("Global/Room/Sql/get_room");
                var data = await dbConnection.QueryAsync<RoomDto>(query, parameters);
                var result = new RoomItemDto
                {
                    DataOfRecords = data.Count(),
                    RoomList = data.ToList(),
                };
                return new ApiResponse<RoomItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RoomItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse<RoomDto>> GetSingleRoom(GetSingleRoomCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RoomCode", request.FilterRoomCode);

                var query = await queryLoader.LoadQueryAsync("Global/Room/Sql/get_single_room");

                var data = await dbConnection.QueryFirstOrDefaultAsync<RoomDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<RoomDto>(HttpStatusCode.NotFound, "data not found");
                }
                return new ApiResponse<RoomDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RoomDto>(
                                        HttpStatusCode.BadRequest,
                                        "An error occurred while retrieving data.",
                                        ex.Message
                                    );
            }
        }

        public async Task<ApiResponse<RoomItemDto>> GetRoomByCriteria(GetRoomByCriteriaCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RoomCode", request.FilterRoomCode ?? string.Empty);
                parameters.Add("@RoomName", request.FilterRoomName ?? string.Empty);
                parameters.Add("@BuildingCode", request.FilterBuildingCode ?? string.Empty);


                var query = await queryLoader.LoadQueryAsync("Global/Room/Sql/get_criteria_room");
                var data = await dbConnection.QueryAsync<RoomDto>(query, parameters);
                var result = new RoomItemDto
                {
                    DataOfRecords = data.Count(),
                    RoomList = data.ToList(),
                };
                return new ApiResponse<RoomItemDto>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<RoomItemDto>(
                         HttpStatusCode.BadRequest,
                         "An error occurred while retrieving data.",
                         ex.Message
                     );
            }
        }

        public async Task<ApiResponse> SubmitRoom(SubmitRoomCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RoomCode", request.RoomCode);
                parameters.Add("@RoomName", request.RoomName);
                parameters.Add("@BuildingCode", request.BuildingCode);
                parameters.Add("@Action", request.Action);
                var userName = currentUserService.GetUserName();
                parameters.Add("@User", string.IsNullOrWhiteSpace(userName) ? "admin" : userName);

                var query = await queryLoader.LoadQueryAsync("Global/Room/Sql/submitroom");
                await dbConnection.ExecuteAsync(query, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"{request.Action} {request.RoomCode} successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action} {request.RoomCode}", ex.Message.ToString());
            }
        }

        public async Task<ApiResponse> DeleteRoom(DeleteRoomCommand request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RoomCode", request.RoomCode);

                var query = await queryLoader.LoadQueryAsync("Global/Room/Sql/get_single_room");

                var data = await dbConnection.QueryFirstOrDefaultAsync<RoomDto>(query, parameters);
                if (data == null)
                {
                    return new ApiResponse<RoomDto>(HttpStatusCode.NotFound, "data not found");
                }
                var query_delete = await queryLoader.LoadQueryAsync("Global/Room/Sql/deleteroom");
                await dbConnection.ExecuteAsync(query_delete, parameters);
                return new ApiResponse(HttpStatusCode.OK, $"Delete successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to delete", ex.Message.ToString());
            }
        }

    }
}
