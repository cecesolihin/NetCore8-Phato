DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    BuildingCode,
    BuildingName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMBuilding
WHERE
    (@BuildingCode IS NULL OR BuildingCode LIKE '%' + @BuildingCode + '%') AND
    (@BuildingName IS NULL OR BuildingName LIKE '%' + @BuildingName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'BuildingCode' THEN BuildingCode END,
    CASE WHEN @SortBy = 'BuildingName' THEN BuildingName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;