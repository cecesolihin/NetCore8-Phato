IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMTaxLocation
    (
        TaxLocationCode,
        TaxLocationName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @TaxLocationCode,
        @TaxLocationName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMTaxLocation
    SET
        TaxLocationCode = @TaxLocationCode,
        TaxLocationName   = @TaxLocationName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        TaxLocationCode = @TaxLocationCode;
END	