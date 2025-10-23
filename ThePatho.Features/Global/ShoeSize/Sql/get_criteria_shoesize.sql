SELECT 
    ShoeSizeCode,
    ShoeSizeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMShoeSize
WHERE
    (@ShoeSizeCode IS NULL OR ShoeSizeCode LIKE '%' + @ShoeSizeCode + '%') AND
    (@ShoeSizeName IS NULL OR ShoeSizeName LIKE '%' + @ShoeSizeName + '%')