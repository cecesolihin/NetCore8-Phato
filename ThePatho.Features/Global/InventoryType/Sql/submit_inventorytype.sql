IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMInventoryType
    (
        InventoryTypeCode,
        InventoryName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @InventoryTypeCode,
        @InventoryName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMInventoryType
    SET
        InventoryTypeCode = @InventoryTypeCode,
        InventoryName   = @InventoryName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        InventoryTypeCode = @InventoryTypeCode;
END	