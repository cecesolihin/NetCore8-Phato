DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    ProfiencyCode,
    ProfiencyName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMSkillProfiency
WHERE
    (@ProfiencyCode IS NULL OR ProfiencyCode LIKE '%' + @ProfiencyCode + '%') AND
    (@ProfiencyName IS NULL OR ProfiencyName LIKE '%' + @ProfiencyName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'ProfiencyCode' THEN ProfiencyCode END,
    CASE WHEN @SortBy = 'ProfiencyName' THEN ProfiencyName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;