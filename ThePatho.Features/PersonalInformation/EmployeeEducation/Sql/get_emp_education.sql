DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    eed.EmployeeEducationID,
    eed.EmployeeID,
    eed.EduLevelCode,
    eed.Faculty,
    eed.MajorCode,
    eed.OtherMajor,
    eed.StartYear,
    eed.EndYear,
    eed.GPA,
    eed.MaxGPA,
    eed.Institution,
    eed.Address,
    eed.CityId,
    eed.GradTypeCode,
    eed.CertificateNo,
    CONVERT(VARCHAR, CertificateDate, 106) AS CertificateDate,--eed.CertificateDate,
    eed.Remarks,
    eed.InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,--eed.InsertedDate,
    eed.ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate,--eed.ModifiedDate,
    eed.IsDeleted
FROM TEPDEmployeeEducation eed
WHERE eed.IsDeleted = 0
  AND (@EmployeeId > 0 AND eed.EmployeeID = @EmployeeId)
  AND ( @EduLevel IS NULL OR @EduLevel = ''
        OR eed.EduLevelCode LIKE '%' +@EduLevel +'%'
        OR eed.MajorCode LIKE '%' +@EduLevel +'%'
        OR eed.Institution LIKE '%' +@EduLevel +'%'
        OR eed.Faculty LIKE '%' +@EduLevel +'%'
  )
ORDER BY
    CASE WHEN @OrderBy = 'ASC' THEN
        CASE 
            WHEN @SortBy = 'Institution' THEN eed.Institution
            WHEN @SortBy = 'EduLevelCode' THEN eed.EduLevelCode
            ELSE CAST(eed.EmployeeEducationID AS NVARCHAR)
        END
    END ASC,
    CASE WHEN @OrderBy = 'DESC' THEN
        CASE 
            WHEN @SortBy = 'Institution' THEN eed.Institution
            WHEN @SortBy = 'EduLevelCode' THEN eed.EduLevelCode
            ELSE CAST(eed.EmployeeEducationID AS NVARCHAR)
        END
    END DESC
OFFSET (@PageNumber - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;
