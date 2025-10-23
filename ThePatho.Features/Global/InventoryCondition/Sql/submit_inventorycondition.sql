IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMInventoryCondition
    (
        InventoryConditionCode,
        InventoryConditionName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @InventoryConditionCode,
        @InventoryConditionName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMInventoryCondition
    SET
        InventoryConditionCode = @InventoryConditionCode,
        InventoryConditionName   = @InventoryConditionName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        InventoryConditionCode = @InventoryConditionCode;
END	