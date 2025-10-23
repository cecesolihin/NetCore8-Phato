SELECT 
    GradTypeCode,
    GradTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMGraduationType
WHERE
    (@GradTypeCode IS NULL OR GradTypeCode LIKE '%' + @GradTypeCode + '%') AND
    (@GradTypeName IS NULL OR GradTypeName LIKE '%' + @GradTypeName + '%') 