SELECT 
    MaritalStatusCode,
    MaritalStatusName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMMaritalStatus
WHERE
    MaritalStatusCode = @MaritalStatusCode