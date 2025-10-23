DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    InventoryConditionCode,
    InventoryConditionName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMInventoryCondition
WHERE
    (@InventoryConditionCode IS NULL OR InventoryConditionCode LIKE '%' + @InventoryConditionCode + '%') AND
    (@InventoryConditionName IS NULL OR InventoryConditionName LIKE '%' + @InventoryConditionName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'InventoryConditionCode' THEN InventoryConditionCode END,
    CASE WHEN @SortBy = 'InventoryConditionName' THEN InventoryConditionName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
