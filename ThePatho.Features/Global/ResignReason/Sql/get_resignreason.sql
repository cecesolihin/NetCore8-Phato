DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    ResignReasonCode,
    ResignReasonName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMResignReason
WHERE
    (@ResignReasonCode IS NULL OR ResignReasonCode LIKE '%' + @ResignReasonCode + '%') AND
    (@ResignReasonName IS NULL OR ResignReasonName LIKE '%' + @ResignReasonName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'ResignReasonCode' THEN ResignReasonCode END,
    CASE WHEN @SortBy = 'ResignReasonName' THEN ResignReasonName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;