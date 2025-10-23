SELECT 
    MaritalStatusCode,
    MaritalStatusName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMMaritalStatus
WHERE
    (@MaritalStatusCode IS NULL OR MaritalStatusCode LIKE '%' + @MaritalStatusCode + '%') AND
    (@MaritalStatusName IS NULL OR MaritalStatusName LIKE '%' + @MaritalStatusName + '%') 