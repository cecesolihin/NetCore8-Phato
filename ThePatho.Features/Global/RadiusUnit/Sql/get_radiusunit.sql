DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    RadiusUnitCode,
    RadiusUnitName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMRadiusUnit
WHERE
    (@RadiusUnitCode IS NULL OR RadiusUnitCode LIKE '%' + @RadiusUnitCode + '%') AND
    (@RadiusUnitName IS NULL OR RadiusUnitName LIKE '%' + @RadiusUnitName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'RadiusUnitCode' THEN RadiusUnitCode END,
    CASE WHEN @SortBy = 'RadiusUnitName' THEN RadiusUnitName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;