IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMShoeSize
    (
        ShoeSizeCode,
        ShoeSizeName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @ShoeSizeCode,
        @ShoeSizeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMShoeSize
    SET
        ShoeSizeCode = @ShoeSizeCode,
        ShoeSizeName   = @ShoeSizeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        ShoeSizeCode = @ShoeSizeCode;
END	