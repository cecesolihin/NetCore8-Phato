IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMSkillProfiency
    (
        ProfiencyCode,
        ProfiencyName,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @ProfiencyCode,
        @ProfiencyName,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMSkillProfiency
    SET
        ProfiencyCode = @ProfiencyCode,
        ProfiencyName   = @ProfiencyName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        ProfiencyCode = @ProfiencyCode;
END	