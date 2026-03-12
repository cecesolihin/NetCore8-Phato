param(
    [string]$ControllersDir = "d:\COURSES\ThePatho\ThePatho\Controllers\Global"
)

$controllerFiles = Get-ChildItem -Path $ControllersDir -Filter "*Controller.cs" -File

foreach ($file in $controllerFiles) {
    Write-Host "Processing $($file.Name)..."
    $moduleName = $file.Name -replace "Controller\.cs", ""

    $content = Get-Content -Path $file.FullName -Raw

    # Ensure necessary usings exist
    if ($content -notmatch "using Microsoft\.AspNetCore\.StaticFiles;") {
        $content = "using Microsoft.AspNetCore.StaticFiles;`r`n" + $content
    }
    if ($content -notmatch "using ThePatho\.Domain\.Constants;") {
        $content = "using ThePatho.Domain.Constants;`r`n" + $content
    }
    if ($content -notmatch "using ThePatho\.Features\.Global\.$moduleName\.Commands;") {
        $content = "using ThePatho.Features.Global.$moduleName.Commands;`r`n" + $content
    }

    $exportEndpoint = @"
        [HttpGet(ApiRoutes.Methods.Export)]
        public async Task<IActionResult> Export$($moduleName)([FromQuery] string type, CancellationToken cancellationToken)
        {
            var exportResponse = await mediator.Send(new Export$($moduleName)Command { Type = type }, cancellationToken);

            if (exportResponse.Code != 200 || exportResponse.Data == null || exportResponse.Data.Base64Data != null)
            {
                return ApiResult(exportResponse);
            }

            var contentType = exportResponse.Data.ContentType;
            if (string.IsNullOrWhiteSpace(contentType))
            {
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(exportResponse.Data.FileName, out contentType))
                {
                    contentType = MimeTypesConstants.APPLICATION_OCTET_STREAM;
                }
            }

            return File(exportResponse.Data.Base64Data, contentType, exportResponse.Data.FileName);
        }
"@

    # Remove any existing [HttpGet(ApiRoutes.Methods.Export)]
    # This regex is a bit delicate, matching from the annotation to the end of the method body.
    $content = $content -replace "(?s)[ \t]*\[HttpGet\(ApiRoutes\.Methods\.Export\)\]\s*public async Task<IActionResult> Export[^\(]*\([^\{]+\{[\s\S]*?return File\([^;]+;\s*\}", ""
    # Also remove any incorrect old endpoint if they named it without [HttpGet(ApiRoutes.Methods.Export)] or something
    # Actually, the user said they may not have it yet. Let's just remove the exact signature matching `Export.*` and `ExportCostCenter` if present
    $content = $content -replace "(?s)[ \t]*\[HttpGet\(ApiRoutes\.Methods\.Export\)\]\s*public async Task<IActionResult> Export[^\(]*\([^\{]*\{.*?(?=return\s+ApiResult|return\s+File)return[^}]+\}", ""

    # It's safer to just inject it before the last `    }` (end of class).
    # Since there are namespace and class braces, typically `    }` followed by `}`.
    $content = $content -replace "(?s)(\s*}\s*}\s*)$", "`r`n$exportEndpoint$1"

    Set-Content -Path $file.FullName -Value $content
}
Write-Host "Done"
