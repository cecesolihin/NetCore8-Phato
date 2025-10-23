IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMEduLevel
    (
        EduLevelCode,
        EduLevelName,
        Sort,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @EduLevelCode,
        @EduLevelName,
        @Sort,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMEduLevel
    SET
        EduLevelCode = @EduLevelCode,
        EduLevelName   = @EduLevelName,
        Sort   = @Sort,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        EduLevelCode = @EduLevelCode;
END	