UPDATE
    dbo.TGEMGraduationType
SET IsDeleted = 1
WHERE
    GradTypeCode = @GradTypeCode