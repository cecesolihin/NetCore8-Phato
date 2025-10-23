DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    MaritalStatusCode,
    MaritalStatusName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMMaritalStatus
WHERE
    (@MaritalStatusCode IS NULL OR MaritalStatusCode LIKE '%' + @MaritalStatusCode + '%') AND
    (@MaritalStatusName IS NULL OR MaritalStatusName LIKE '%' + @MaritalStatusName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'MaritalStatusCode' THEN MaritalStatusCode END,
    CASE WHEN @SortBy = 'MaritalStatusName' THEN MaritalStatusName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
