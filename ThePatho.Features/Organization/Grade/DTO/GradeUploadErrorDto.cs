using System;
using System.Collections.Generic;

namespace ThePatho.Features.Organization.Grade.DTO;

public class GradeUploadErrorDto
{
    public int RowNumber { get; set; }
    public string? GradeCode { get; set; }
    public string? GradeName { get; set; }
    public int? Sort { get; set; }
    public string? Status { get; set; }
    public string? Remarks { get; set; }
    public string Message { get; set; } = string.Empty;
}