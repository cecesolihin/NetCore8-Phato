UPDATE 
    dbo.TGEMEduMajor
SET IsDeleted = 1
WHERE
    MajorCode = @MajorCode