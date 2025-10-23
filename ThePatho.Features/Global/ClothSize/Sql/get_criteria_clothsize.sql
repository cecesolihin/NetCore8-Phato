SELECT 
    ClothSizeCode,
    ClothSizeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMClothSize
WHERE
    (@ClothSizeCode IS NULL OR ClothSizeCode LIKE '%' + @ClothSizeCode + '%') AND
    (@ClothSizeName IS NULL OR ClothSizeName LIKE '%' + @ClothSizeName + '%')