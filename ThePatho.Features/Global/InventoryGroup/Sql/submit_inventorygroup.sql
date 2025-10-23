IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMInventoryGroup
    (
        InventoryGroupCode,
        InventoryGroupName,
        GroupBy,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @InventoryGroupCode,
        @InventoryGroupName,
        @GroupBy,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMInventoryGroup
    SET
        InventoryGroupCode = @InventoryGroupCode,
        InventoryGroupName   = @InventoryGroupName,
        GroupBy   = @GroupBy,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        InventoryGroupCode = @InventoryGroupCode;
END	