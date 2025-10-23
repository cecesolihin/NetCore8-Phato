IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMBloodType
    (
        BloodTypeCode,
        BloodTypeName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @BloodTypeCode,
        @BloodTypeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMBloodType
    SET
        BloodTypeCode = @BloodTypeCode,
        BloodTypeName   = @BloodTypeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        BloodTypeCode = @BloodTypeCode;
END