SELECT 
    EmployeeID,
    InventoryNo,
    InventoryTpyeCode AS InventoryTypeCode,
    InventoryName,
    CONVERT(VARCHAR, ReceivedDate, 106) AS ReceivedDate,--ReceivedDate,
    CONVERT(VARCHAR, ReturnPlanDate, 106) AS ReturnPlanDate,--ReturnPlanDate,
    Qty,
    Size,
    InCondition,
    InRemark,
    CONVERT(VARCHAR, ReturnDate, 106) AS ReturnDate,--ReturnDate,
    CONVERT(VARCHAR, OutCondition, 106) AS OutCondition,--OutCondition,
    OutRemark,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate
FROM 
    dbo.TEPDEmployeeInventory
WHERE
    (@EmployeeId > 0 OR EmployeeID = @EmployeeId) AND
    (@InventoryNo = '' OR InventoryNo LIKE '%' + @InventoryNo + '%') AND
    (@InventoryName = '' OR InventoryName LIKE '%' + @InventoryName + '%') AND
    (@InventoryTypeCode = '' OR InventoryTpyeCode LIKE '%' + @InventoryTypeCode + '%')