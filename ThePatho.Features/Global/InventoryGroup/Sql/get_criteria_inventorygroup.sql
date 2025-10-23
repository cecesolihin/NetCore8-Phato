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