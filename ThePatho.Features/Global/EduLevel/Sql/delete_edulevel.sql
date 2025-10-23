UPDATE
    dbo.TGEMEduLevel
SET IsDeleted = 1
WHERE
    EduLevelCode = @EduLevelCode