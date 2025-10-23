IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMNumericalSize
    (
        NumericalSizeName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @NumericalSizeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMNumericalSize
    SET
        NumericalSizeId = @NumericalSizeId,
        NumericalSizeName   = @NumericalSizeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        NumericalSizeId = @NumericalSizeId;
END	