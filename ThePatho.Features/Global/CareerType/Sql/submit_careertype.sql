IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMCareerType
    (
        CareerTypeCode,
        CareerTypeName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @CareerTypeCode,
        @CareerTypeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMCareerType
    SET
        CareerTypeCode = @CareerTypeCode,
        CareerTypeName   = @CareerTypeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        CareerTypeCode = @CareerTypeCode;
END	