IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMInsurance
    (
        InsuranceCode,
        InsuranceName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @InsuranceCode,
        @InsuranceName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMInsurance
    SET
        InsuranceCode = @InsuranceCode,
        InsuranceName   = @InsuranceName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        InsuranceCode = @InsuranceCode;
END	