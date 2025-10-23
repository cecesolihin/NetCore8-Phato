IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMGraduationType
    (
        GradTypeCode,
        GradTypeName,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @GradTypeCode,
        @GradTypeName,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMGraduationType
    SET
        GradTypeCode = @GradTypeCode,
        GradTypeName   = @GradTypeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        GradTypeCode = @GradTypeCode;
END	