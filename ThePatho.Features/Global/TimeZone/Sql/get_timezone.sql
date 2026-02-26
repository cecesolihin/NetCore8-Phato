DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    TimeZoneCode,
    TimeZoneName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMTimeZone
WHERE
    (@TimeZoneCode IS NULL OR TimeZoneCode LIKE '%' + @TimeZoneCode + '%') AND
    (@TimeZoneName IS NULL OR TimeZoneName LIKE '%' + @TimeZoneName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'TimeZoneCode' THEN TimeZoneCode END,
    CASE WHEN @SortBy = 'TimeZoneName' THEN TimeZoneName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;