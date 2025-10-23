SELECT 
    TaxStatusCode,
    TaxStatusName,
    Married,
    TotalDependents,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMTaxStatus
WHERE
    TaxStatusCode = @TaxStatusCode