DELETE FROM dbo.TEPDEmployeeInventory
    WHERE EmployeeID = @EmployeeId AND InventoryNo = @InventoryNo;