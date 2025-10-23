IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMCountry
    (
         [Name],
        NumericIsoCode,
        ThreeLetterIsoCode,
        TwoLetterIsoCode,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @Name,
        @NumericIsoCode,
        @ThreeLetterIsoCode,
        @TwoLetterIsoCode,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMCountry
    SET
        [Name] = @Name,
        NumericIsoCode   = @NumericIsoCode,
        ThreeLetterIsoCode   = @ThreeLetterIsoCode,
        TwoLetterIsoCode   = @TwoLetterIsoCode,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        BloodTypeCode = @BloodTypeCode;
END	