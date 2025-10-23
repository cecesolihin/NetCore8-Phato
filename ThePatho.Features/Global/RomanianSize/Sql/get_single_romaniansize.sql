SELECT 
    RomanianSizeId,
    RomanianSizeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMRomanianSize
WHERE
    RomanianSizeId = @RomanianSizeId