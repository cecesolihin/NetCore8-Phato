DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    InventoryGroupCode,
    InventoryGroupName,
    GroupBy,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMInventoryGroup
WHERE
    (@InventoryGroupCode IS NULL OR InventoryGroupCode LIKE '%' + @InventoryGroupCode + '%') AND
    (@InventoryGroupName IS NULL OR InventoryGroupName LIKE '%' + @InventoryGroupName + '%') AND
    (@GroupBy IS NULL OR GroupBy LIKE '%' + @GroupBy + '%') 
ORDER BY
    CASE WHEN @SortBy = 'InventoryGroupCode' THEN InventoryGroupCode END,
    CASE WHEN @SortBy = 'InventoryGroupName' THEN InventoryGroupName END,
    CASE WHEN @SortBy = 'GroupBy' THEN InventoryGroupName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
