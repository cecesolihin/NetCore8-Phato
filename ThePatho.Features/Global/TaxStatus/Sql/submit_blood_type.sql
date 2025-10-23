IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMTaxStatus
    (
        TaxStatusCode,
        TaxStatusName,
        Married,
        TotalDependents,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @TaxStatusCode,
        @TaxStatusName,
        @Married,
        @TotalDependents,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMTaxStatus
    SET
        TaxStatusCode = @TaxStatusCode,
        TaxStatusName   = @TaxStatusName,
        Married   = @Married,
        TotalDependents   = @TotalDependents,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        TaxStatusCode = @TaxStatusCode;
END