SELECT 
    BloodTypeCode,
    BloodTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMBloodType
WHERE
    (@BloodTypeCode IS NULL OR BloodTypeCode LIKE '%' + @BloodTypeCode + '%') AND
    (@BloodTypeName IS NULL OR BloodTypeName LIKE '%' + @BloodTypeName + '%') 