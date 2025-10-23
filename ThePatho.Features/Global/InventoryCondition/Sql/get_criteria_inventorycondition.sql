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