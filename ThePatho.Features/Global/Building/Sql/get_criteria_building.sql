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