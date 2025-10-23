UPDATE
    dbo.TGEMDiseaseCategory
SET IsDeleted =1
WHERE
    DiseaseCategoryCode = @DiseaseCategoryCode