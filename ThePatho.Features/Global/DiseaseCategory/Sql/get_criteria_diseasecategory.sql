SELECT 
    DiseaseCategoryCode,
    DiseaseCategoryName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMDiseaseCategory
WHERE
    (@DiseaseCategoryCode IS NULL OR DiseaseCategoryCode LIKE '%' + @DiseaseCategoryCode + '%') AND
    (@DiseaseCategoryName IS NULL OR DiseaseCategoryName LIKE '%' + @DiseaseCategoryName + '%') 