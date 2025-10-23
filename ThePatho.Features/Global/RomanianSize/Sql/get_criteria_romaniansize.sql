SELECT 
    RomanianSizeId,
    RomanianSizeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMRomanianSize
WHERE
    (@RomanianSizeName IS NULL OR RomanianSizeName LIKE '%' + @RomanianSizeName + '%')