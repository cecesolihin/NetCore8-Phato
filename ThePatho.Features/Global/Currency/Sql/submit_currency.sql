IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMCurrency
    (
        CurrencyCode,
        CurrencyName,
        Symbol ,
        DecimalDigit ,
        IsDefault , 
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @CurrencyCode,
        @CurrencyName,
        @Symbol ,
        @DecimalDigit ,
        @IsDefault , 
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMCurrency
    SET
        CurrencyCode = @CurrencyCode,
        CurrencyName   = @CurrencyName,
        Symbol = @Symbol,
        DecimalDigit = @DecimalDigit,
        IsDefault = @IsDefault,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        CurrencyCode = @CurrencyCode;
END	