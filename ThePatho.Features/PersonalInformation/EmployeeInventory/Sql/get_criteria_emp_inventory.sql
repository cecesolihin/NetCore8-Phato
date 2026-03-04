SELECT 
    inv.EmployeeID,
    emp.EmployeeNo,
    emp.Fullname AS EmployeeName,
    emp.PositionCode,
    pos.PositionName,

    inv.InventoryNo,
    inv.InventoryTpyeCode AS InventoryTypeCode,
    inv.InventoryName,
    CONVERT(VARCHAR, inv.ReceivedDate, 106) AS ReceivedDate,
    CONVERT(VARCHAR, inv.ReturnPlanDate, 106) AS ReturnPlanDate,
    inv.Qty,
    inv.ReceivedQty,
    inv.ReceivedCondition,
    inv.ReceivedRemark,
    CONVERT(VARCHAR, inv.ReturnDate, 106) AS ReturnDate,
    inv.ReturnCondition,
    inv.ReturnRemark,
    inv.InsertedBy,
    CONVERT(VARCHAR, inv.InsertedDate, 106) AS InsertedDate,
    inv.ModifiedBy,
    CONVERT(VARCHAR, inv.ModifiedDate, 106) AS ModifiedDate

FROM dbo.TEPDEmployeeInventory inv
INNER JOIN TEPMEmployee emp 
    ON inv.EmployeeID = emp.EmployeeID
LEFT JOIN TOGMPosition pos 
    ON emp.PositionCode = pos.PositionCode

WHERE
    (@EmployeeId = 0 OR inv.EmployeeID = @EmployeeId)
    AND
    (
        @Inventory IS NULL OR @Inventory = ''
        OR inv.InventoryNo LIKE '%' + @Inventory + '%'
        OR inv.InventoryName LIKE '%' + @Inventory + '%'
        OR inv.InventoryTpyeCode LIKE '%' + @Inventory + '%'
    )
