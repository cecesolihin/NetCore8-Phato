DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    MajorCode,
    MajorName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMEduMajor
WHERE
    (@MajorCode IS NULL OR MajorCode LIKE '%' + @MajorCode + '%') AND
    (@MajorName IS NULL OR MajorName LIKE '%' + @MajorName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'MajorCode' THEN MajorCode END,
    CASE WHEN @SortBy = 'MajorName' THEN MajorName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
