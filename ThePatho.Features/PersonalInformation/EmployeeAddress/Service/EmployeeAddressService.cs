using Dapper;
using System.Data;
using System.Net;
using ThePatho.Features.PersonalInformation.EmployeeAddress.Commands;
using ThePatho.Features.PersonalInformation.EmployeeAddress.DTO;
using ThePatho.Infrastructure.Persistance;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.UserContext;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ThePatho.Features.Common.DTO;
using ThePatho.Domain.Constants;
using System.IO;

namespace ThePatho.Features.PersonalInformation.EmployeeAddress.Service
{
    public class EmployeeAddressService : IEmployeeAddressService
    {
        #region [FIELDS]
        private readonly SqlQueryLoader queryLoader;
        private readonly IDbConnection dbConnection;
        private readonly DapperContext dapperContext;
        private readonly ApplicationDbContext context;
        private readonly ICurrentUserService currentUserService;
        #endregion

        #region [CTOR]
        public EmployeeAddressService(DapperContext _dapperContext, SqlQueryLoader _queryLoader, ICurrentUserService _currentUserService)
        {
            dapperContext = _dapperContext;
            queryLoader = _queryLoader;
            currentUserService = _currentUserService;
        }
        #endregion

        #region [METHODS]
   
        public async Task<ApiResponse<EmployeeAddressDto>> GetSingleEmployeeAddress(GetSingleEmployeeAddressCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeAddress/Sql/get_single_emp_address");
                var data = await db.QueryFirstOrDefaultAsync<EmployeeAddressDto>(query, parameters);

                return new ApiResponse<EmployeeAddressDto>(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return new ApiResponse<EmployeeAddressDto>(HttpStatusCode.BadRequest, "Error retrieving Employee Address detail.", ex.Message);
            }
        }

        public async Task<ApiResponse> SubmitEmployeeAddress(SubmitEmployeeAddressCommand request)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", request.EmployeeId);
                parameters.Add("@CompanyCode", request.CompanyCode);
                parameters.Add("@Address", request.Address);
                parameters.Add("@Rt", request.Rt);
                parameters.Add("@Rw", request.Rw);
                parameters.Add("@SubDistrict", request.SubDistrict);
                parameters.Add("@District", request.District);
                parameters.Add("@CityId", request.CityId);
                parameters.Add("@ProvinceId", request.ProvinceId);
                parameters.Add("@CountryId", request.CountryId);
                parameters.Add("@ZipCode", request.ZipCode);
                parameters.Add("@OwnershipCode", request.OwnershipCode);
                parameters.Add("@CurrAddress", request.CurrAddress);
                parameters.Add("@CurrRt", request.CurrRt);
                parameters.Add("@CurrRw", request.CurrRw);
                parameters.Add("@CurrSubDistrict", request.CurrSubDistrict);
                parameters.Add("@CurrDistrict", request.CurrDistrict);
                parameters.Add("@CurrCityId", request.CurrCityId);
                parameters.Add("@CurrProvinceId", request.CurrProvinceId);
                parameters.Add("@CurrCountryId", request.CurrCountryId);
                parameters.Add("@CurrZipCode", request.CurrZipCode);
                parameters.Add("@CurrOwnershipCode", request.CurrOwnershipCode);
                parameters.Add("@IsDeleted", request.IsDeleted);
                parameters.Add("@InsertedBy", request.InsertedBy);
                parameters.Add("@InsertedDate", request.InsertedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@Action", request.Action);
                parameters.Add("@User", currentUserService.GetUserName() ?? "admin");

                var query = await queryLoader.LoadQueryAsync("PersonalInformation/EmployeeAddress/Sql/submit_emp_address");
                await db.ExecuteAsync(query, parameters);

                return new ApiResponse(HttpStatusCode.OK, $"{request.Action}  successful");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, $"Failed to {request.Action}", ex.Message);
            }
        }

        public async Task<ApiResponse<AttachmentFileDto>> ExportEmployeeAddressAsync(string type)
        {
            try
            {
                using var db = dapperContext.CreateConnection();
                // For now, I'll export all non-deleted addresses
                var data = await db.QueryAsync<EmployeeAddressDto>("SELECT * FROM EmployeeAddress WHERE IsDeleted = 0");

                var fileName = string.Empty;
                byte[] fileBytes;

                if (string.Equals(type, "excel", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(type, "xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    using var workbook = new XLWorkbook();
                    var ws = workbook.Worksheets.Add("EmployeeAddress");

                    ws.Cell("A1").Value = "Employee Address List";
                    ws.Range("A1:E1").Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    string[] headers = { "Employee ID", "Address", "Sub District", "District", "City" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = ws.Cell(3, i + 1);
                        cell.Value = headers[i];
                        cell.Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromHtml("#3DCBE0"));
                    }

                    var row = 4;
                    foreach (var item in data)
                    {
                        ws.Cell(row, 1).Value = item.EmployeeId;
                        ws.Cell(row, 2).Value = item.Address;
                        ws.Cell(row, 3).Value = item.SubDistrict;
                        ws.Cell(row, 4).Value = item.District;
                        ws.Cell(row, 5).Value = item.CityId;
                        row++;
                    }

                    ws.Columns(1, 5).AdjustToContents();
                    using var ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeAddressList_{DateTime.Now:yyyyMMdd}.xlsx";

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    });
                }
                else if (string.Equals(type, "pdf", StringComparison.OrdinalIgnoreCase))
                {
                    var document = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Header().AlignCenter().Text("Employee Address List").SemiBold().FontSize(16);
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(50);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).Padding(5).Text("ID").Bold();
                                    header.Cell().Border(1).Padding(5).Text("Address").Bold();
                                    header.Cell().Border(1).Padding(5).Text("Sub District").Bold();
                                    header.Cell().Border(1).Padding(5).Text("District").Bold();
                                });
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(5).Text(item.EmployeeId.ToString());
                                    table.Cell().Border(1).Padding(5).Text(item.Address ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.SubDistrict ?? "-");
                                    table.Cell().Border(1).Padding(5).Text(item.District ?? "-");
                                }
                            });
                        });
                    });

                    using var ms = new MemoryStream();
                    document.GeneratePdf(ms);
                    fileBytes = ms.ToArray();
                    fileName = $"EmployeeAddressList_{DateTime.Now:yyyyMMdd}.pdf";

                    return new ApiResponse<AttachmentFileDto>(HttpStatusCode.OK, new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(fileBytes),
                        FileName = fileName,
                        ContentType = MimeTypesConstants.PDF
                    });
                }

                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.BadRequest, null, "Invalid export type.");
            }
            catch (Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(HttpStatusCode.InternalServerError, null, ex.Message);
            }
        }

        #endregion
    }
}

