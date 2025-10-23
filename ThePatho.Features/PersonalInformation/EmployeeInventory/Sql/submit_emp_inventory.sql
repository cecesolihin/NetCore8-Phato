IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TEPDEmployeeInventory
    (
        EmployeeID,
        InventoryNo,
        InventoryTpyeCode,
        InventoryName,
        ReceivedDate,
        ReturnPlanDate,
        Qty,
        Size,
        InCondition,
        InRemark,
        ReturnDate,
        OutCondition,
        OutRemark,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @EmployeeId,
        @InventoryNo,
        @InventoryTypeCode,
        @InventoryName,
        @ReceivedDate,
        @ReturnPlanDate,
        @Qty,
        @Size,
        @InCondition,
        @InRemark,
        @ReturnDate,
        @OutCondition,
        @OutRemark,
        @User,
        GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TEPDEmployeeInventory
    SET
        InventoryTpyeCode = @InventoryTypeCode,
        InventoryName = @InventoryName,
        ReceivedDate = @ReceivedDate,
        ReturnPlanDate = @ReturnPlanDate,
        Qty = @Qty,
        Size = @Size,
        InCondition = @InCondition,
        InRemark = @InRemark,
        ReturnDate = @ReturnDate,
        OutCondition = @OutCondition,
        OutRemark = @OutRemark,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeID = @EmployeeId AND InventoryNo = @InventoryNo;
END

