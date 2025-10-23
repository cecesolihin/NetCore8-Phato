DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    IdentityCode,
    IdentityName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMIdentity
WHERE
    (@IdentityCode IS NULL OR IdentityCode LIKE '%' + @IdentityCode + '%') AND
    (@IdentityName IS NULL OR IdentityName LIKE '%' + @IdentityName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'IdentityCode' THEN IdentityCode END,
    CASE WHEN @SortBy = 'IdentityName' THEN IdentityName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;