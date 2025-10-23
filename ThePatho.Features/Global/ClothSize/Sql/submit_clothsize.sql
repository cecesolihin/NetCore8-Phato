IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMClothSize
    (
        ClothSizeCode,
        ClothSizeName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @ClothSizeCode,
        @ClothSizeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMClothSize
    SET
        ClothSizeCode = @ClothSizeCode,
        ClothSizeName   = @ClothSizeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        ClothSizeCode = @ClothSizeCode;
END	