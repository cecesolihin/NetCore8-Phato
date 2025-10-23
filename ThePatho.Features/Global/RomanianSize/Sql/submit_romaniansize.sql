IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMRomanianSize
    (
        RomanianSizeId,
        RomanianSizeName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @RomanianSizeId,
        @RomanianSizeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMRomanianSize
    SET
        RomanianSizeId = @RomanianSizeId,
        RomanianSizeName   = @RomanianSizeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        RomanianSizeId = @RomanianSizeId;
END	