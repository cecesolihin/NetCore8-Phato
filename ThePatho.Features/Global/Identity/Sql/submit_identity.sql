IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMIdentity
    (
        IdentityCode,
        IdentityName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @IdentityCode,
        @IdentityName,
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