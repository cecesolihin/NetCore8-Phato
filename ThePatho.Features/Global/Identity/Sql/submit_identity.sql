IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMIdentity
    (
        IdentityCode,
        IdentityName,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @IdentityCode,
        @IdentityName,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMIdentity
    SET
        IdentityCode = @IdentityCode,
        IdentityName   = @IdentityName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        IdentityCode = @IdentityCode;
END	