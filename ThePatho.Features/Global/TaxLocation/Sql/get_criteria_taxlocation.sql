SELECT 
    TaxLocationCode,
    TaxLocationName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMTaxLocation
WHERE
    (@TaxLocationCode IS NULL OR TaxLocationCode LIKE '%' + @TaxLocationCode + '%') AND
    (@TaxLocationName IS NULL OR TaxLocationName LIKE '%' + @TaxLocationName + '%') 