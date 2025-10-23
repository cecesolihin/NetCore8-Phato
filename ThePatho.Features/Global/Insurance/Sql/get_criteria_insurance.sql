SELECT 
    InsuranceCode,
    InsuranceName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMInsurance
WHERE
    (@InsuranceCode IS NULL OR InsuranceCode LIKE '%' + @InsuranceCode + '%') AND
    (@InsuranceName IS NULL OR InsuranceName LIKE '%' + @InsuranceName + '%') 