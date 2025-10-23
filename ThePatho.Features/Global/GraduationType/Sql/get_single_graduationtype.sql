SELECT 
    GradTypeCode,
    GradTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMGraduationType
WHERE
    GradTypeCode = @GradTypeCode