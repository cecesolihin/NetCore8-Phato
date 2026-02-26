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