param(
    [string]$GlobalDir = "d:\COURSES\ThePatho\ThePatho.Features\Global"
)

$modules = Get-ChildItem -Path $GlobalDir -Directory | Select-Object -ExpandProperty Name

foreach ($module in $modules) {
    Write-Host "Processing $module..."

    $commandsDir = Join-Path $GlobalDir "$module\Commands"
    if (-not (Test-Path $commandsDir)) { New-Item -ItemType Directory -Path $commandsDir | Out-Null }
    
    $handlersDir = Join-Path $commandsDir "Handlers"
    if (-not (Test-Path $handlersDir)) { New-Item -ItemType Directory -Path $handlersDir | Out-Null }

    $commandFile = Join-Path $commandsDir "Export$($module)Command.cs"
    if (-not (Test-Path $commandFile)) {
        $cmdContent = @"
using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.$module.Commands
{
    public class Export$($module)Command : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; } = `"excel`"; // `"excel`" or `"pdf`"
    }
}
"@
        Set-Content -Path $commandFile -Value $cmdContent
    }

    $handlerFile = Join-Path $handlersDir "Export$($module)CommandHandler.cs"
    if (-not (Test-Path $handlerFile)) {
        $handlerContent = @"
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.$module.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.$module.Commands.Handlers
{
    public class Export$($module)CommandHandler : IRequestHandler<Export$($module)Command, ApiResponse<AttachmentFileDto>>
    {
        private readonly I$($module)Service _service;
        public Export$($module)CommandHandler(I$($module)Service service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(Export$($module)Command request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
"@
        Set-Content -Path $handlerFile -Value $handlerContent
    }

    # Updating I[Module]Service.cs
    $iServiceFile = Join-Path $GlobalDir "$module\Service\I$($module)Service.cs"
    if (Test-Path $iServiceFile) {
        $iServiceContent = Get-Content -Path $iServiceFile -Raw
        if ($iServiceContent -notmatch "Task<ApiResponse<AttachmentFileDto>> ExportAsync") {
            if ($iServiceContent -notmatch "using ThePatho.Features.Common.DTO;") {
                $iServiceContent = "using ThePatho.Features.Common.DTO;`r`n" + $iServiceContent
            }
            # Add ExportAsync before the final '}'
            $iServiceContent = $iServiceContent -replace "(?s)(\s*}\s*}\s*)$", "`r`n        Task<ApiResponse<AttachmentFileDto>> ExportAsync(Export$($module)Command request);`r`n$1"
            Set-Content -Path $iServiceFile -Value $iServiceContent
        }
    }

    # Updating [Module]Service.cs
    $serviceFile = Join-Path $GlobalDir "$module\Service\$($module)Service.cs"
    if (Test-Path $serviceFile) {
        $serviceContent = Get-Content -Path $serviceFile -Raw
        if ($serviceContent -notmatch "Task<ApiResponse<AttachmentFileDto>> ExportAsync\(Export$($module)") {
            
            # Ensure Using Statements
            $usings = "using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Reflection;
using ThePatho.Domain.Constants;
using ThePatho.Features.Common.DTO;
"
            # prepend if missing
            if ($serviceContent -notmatch "using ClosedXML\.Excel;") {
                $serviceContent = $usings + "`r`n" +  $serviceContent
            }

            # Inject the standard export method
            $methodBlock = @"
        public async Task<ApiResponse<AttachmentFileDto>> ExportAsync(Export$($module)Command request)
        {
            try
            {
                var criteriaRequest = new Get$($module)ByCriteriaCommand();
                var response = await Get$($module)ByCriteria(criteriaRequest);
                var data = response.Data?.$($module)List ?? new System.Collections.Generic.List<$($module)Dto>();

                var type = (request.Type ?? `"`").Trim().ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(type)) type = `"excel`";

                if (type == `"excel`" || type == `"xlsx`")
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add(`"$($module)List`");

                    // Title
                    worksheet.Cell(`"A1`").Value = `"$($module) List`";
                    worksheet.Range(`"A1:F1`").Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    // Header
                    worksheet.Cell(3, 1).Value = `"No`";
                    var properties = typeof($($module)Dto).GetProperties();
                    int col = 2;
                    foreach (var prop in properties)
                    {
                        worksheet.Cell(3, col).Value = prop.Name;
                        col++;
                    }

                    worksheet.Range(3, 1, 3, col - 1).Style
                        .Font.SetBold()
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Fill.SetBackgroundColor(XLColor.FromHtml(`"#3DCBE0`"));

                    // Data
                    var row = 4;
                    int no = 1;

                    foreach (var item in data)
                    {
                        worksheet.Cell(row, 1).Value = no++;
                        int dataCol = 2;
                        foreach (var prop in properties)
                        {
                            var val = prop.GetValue(item);
                            if (val is bool b)
                            {
                                worksheet.Cell(row, dataCol).Value = b ? `"Active`" : `"Inactive`";
                            }
                            else
                            {
                                worksheet.Cell(row, dataCol).Value = val?.ToString() ?? `"`";
                            }
                            dataCol++;
                        }
                        row++;
                    }

                    worksheet.Columns(1, col - 1).AdjustToContents();

                    var lastDataRow = row > 4 ? row - 1 : 3;
                    if (col > 1) {
                        var tableRange = worksheet.Range(3, 1, lastDataRow, col - 1);
                        tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    }

                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();

                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = `"$($module)List.xlsx`",
                        ContentType = MimeTypesConstants.VND_OPENXML_EXCEL
                    };

                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.OK, dto);
                }
                else if (type == `"pdf`")
                {
                    var doc = Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4.Landscape());

                            // Title
                            page.Header().Element(header =>
                            {
                                header.AlignCenter()
                                    .PaddingBottom(10)
                                    .Text(`"$($module) List Data`")
                                    .SemiBold()
                                    .FontSize(18)
                                    .FontColor(`"#007BFF`");
                            });

                            // Content
                            page.Content().PaddingTop(10).Table(table =>
                            {
                                var properties = typeof($($module)Dto).GetProperties();
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(30);
                                    foreach (var prop in properties) {
                                        columns.RelativeColumn();
                                    }
                                });

                                var headerStyle = TextStyle.Default.FontSize(10).Bold();
                                var normalTextStyle = TextStyle.Default.FontSize(8);

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).PaddingVertical(4).PaddingHorizontal(6).Background(Colors.BlueGrey.Lighten2).AlignCenter().AlignMiddle().Text(`"No`").Style(headerStyle);
                                    foreach (var prop in properties) {
                                        header.Cell().Border(1).PaddingVertical(4).PaddingHorizontal(6).Background(Colors.BlueGrey.Lighten2).AlignCenter().AlignMiddle().Text(prop.Name).Style(headerStyle);
                                    }
                                });

                                var no = 1;
                                foreach (var item in data)
                                {
                                    table.Cell().Border(1).Padding(3).AlignCenter().Text(no.ToString()).Style(normalTextStyle);
                                    foreach (var prop in properties) {
                                        var val = prop.GetValue(item);
                                        var textVal = `"`";
                                        if (val is bool b) {
                                            textVal = b ? `"Active`" : `"Inactive`";
                                        } else {
                                            textVal = val?.ToString() ?? `"-`";
                                        }
                                        table.Cell().Border(1).Padding(3).Text(textVal).Style(normalTextStyle);
                                    }
                                    no++;
                                }
                            });
                        });
                    });

                    var bytes = doc.GeneratePdf();
                    var dto = new AttachmentFileDto
                    {
                        Base64Data = Convert.ToBase64String(bytes),
                        FileName = `"$($module)List.pdf`",
                        ContentType = MimeTypesConstants.PDF
                    };

                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.OK, dto);
                }
                else
                {
                    return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, `"Type harus 'excel' atau 'pdf'`");
                }
            }
            catch (System.Exception ex)
            {
                return new ApiResponse<AttachmentFileDto>(System.Net.HttpStatusCode.BadRequest, default, `"Gagal export $($module)`", ex.Message);
            }
        }
"@
            $serviceContent = $serviceContent -replace "(?s)(\s*}\s*}\s*)$", "`r`n$methodBlock`r`n$1"
            Set-Content -Path $serviceFile -Value $serviceContent
        }
    }
}
Write-Host "Done"
