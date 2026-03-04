SELECT 
    CareerTypeCode,
    CareerTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMCareerType
WHERE
    (@CareerTypeCode IS NULL OR CareerTypeCode LIKE '%' + @CareerTypeCode + '%') AND
    (@CareerTypeName IS NULL OR CareerTypeName LIKE '%' + @CareerTypeName + '%') 