SELECT 
    NumericalSizeId,
    NumericalSizeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMNumericalSize
WHERE
    (@NumericalSizeName IS NULL OR NumericalSizeName LIKE '%' + @NumericalSizeName + '%') 