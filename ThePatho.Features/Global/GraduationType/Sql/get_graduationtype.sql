DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    GradTypeCode,
    GradTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMGraduationType
WHERE
    (@GradTypeCode IS NULL OR GradTypeCode LIKE '%' + @GradTypeCode + '%') AND
    (@GradTypeName IS NULL OR GradTypeName LIKE '%' + @GradTypeName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'GradTypeCode' THEN GradTypeCode END,
    CASE WHEN @SortBy = 'GradTypeName' THEN GradTypeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;