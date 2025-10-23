IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMMaritalStatus
    (
        MaritalStatusCode,
        MaritalStatusName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @MaritalStatusCode,
        @MaritalStatusName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMMaritalStatus
    SET
        MaritalStatusCode = @MaritalStatusCode,
        MaritalStatusName   = @MaritalStatusName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        MaritalStatusCode = @MaritalStatusCode;
END	