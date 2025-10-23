SELECT 
    InventoryGroupCode,
    OrganizationCode,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMDInventoryGroupOrg
WHERE
    (@InventoryGroupCode IS NULL OR InventoryGroupCode LIKE '%' + @InventoryGroupCode + '%') AND
    (@OrganizationCode IS NULL OR OrganizationCode LIKE '%' + @OrganizationCode + '%') 