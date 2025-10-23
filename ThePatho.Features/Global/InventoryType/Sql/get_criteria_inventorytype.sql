SELECT 
    InventoryTypeCode,
    InventoryName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMInventoryType
WHERE
    (@InventoryTypeCode IS NULL OR InventoryTypeCode LIKE '%' + @InventoryTypeCode + '%') AND
    (@InventoryName IS NULL OR InventoryName LIKE '%' + @InventoryName + '%') 