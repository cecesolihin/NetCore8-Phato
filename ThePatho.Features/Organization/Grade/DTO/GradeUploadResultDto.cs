using System.Collections.Generic;

namespace ThePatho.Features.Organization.Grade.DTO;

public class GradeUploadResultDto
{
    public int InsertedCount { get; set; }
    public int UpdatedCount { get; set; }
    public List<GradeUploadErrorDto> Errors { get; set; } = new();
}