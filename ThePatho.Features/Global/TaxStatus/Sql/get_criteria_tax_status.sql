SELECT 
    TaxStatusCode,
    TaxStatusName,
    Married,
    TotalDependents,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMTaxStatus
WHERE
    IsDeleted = 0 AND
    (@TaxStatusCode IS NULL OR TaxStatusCode LIKE '%' + @TaxStatusCode + '%') AND
    (@TaxStatusName IS NULL OR TaxStatusName LIKE '%' + @TaxStatusName + '%') AND
    (@Married IS NULL OR Married LIKE '%' + @Married + '%') AND
    (@TotalDependents > 0 OR TotalDependents =@TotalDependents) 