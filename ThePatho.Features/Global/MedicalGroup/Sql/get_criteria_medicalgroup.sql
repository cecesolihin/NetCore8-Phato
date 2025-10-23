SELECT 
    MedicalGroupCode,
    MedicalGroupName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMMedicalGroup
WHERE
    (@MedicalGroupCode IS NULL OR MedicalGroupCode LIKE '%' + @MedicalGroupCode + '%') AND
    (@MedicalGroupName IS NULL OR MedicalGroupName LIKE '%' + @MedicalGroupName + '%') 