DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
    --inv.Qty,
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
    -- Received Date
    AND (@ReceivedDateFrom IS NULL OR inv.ReceivedDate >= @ReceivedDateFrom)
    AND (@ReceivedDateTo IS NULL OR inv.ReceivedDate <= @ReceivedDateTo)

    -- Return Date
    AND (@ReturnDateFrom IS NULL OR inv.ReturnDate >= @ReturnDateFrom)
    AND (@ReturnDateTo IS NULL OR inv.ReturnDate <= @ReturnDateTo)

    -- Return Plan Date
    AND (@ReturnPlanDateFrom IS NULL OR inv.ReturnPlanDate >= @ReturnPlanDateFrom)
    AND (@ReturnPlanDateTo IS NULL OR inv.ReturnPlanDate <= @ReturnPlanDateTo)
ORDER BY
    CASE WHEN @SortBy = 'InventoryNo' AND @OrderBy = 'ASC' THEN inv.InventoryNo END ASC,
    CASE WHEN @SortBy = 'InventoryNo' AND @OrderBy = 'DESC' THEN inv.InventoryNo END DESC,
    CASE WHEN @SortBy = 'InventoryName' AND @OrderBy = 'ASC' THEN inv.InventoryName END ASC,
    CASE WHEN @SortBy = 'InventoryName' AND @OrderBy = 'DESC' THEN inv.InventoryName END DESC,
    CASE WHEN @SortBy = 'ReceivedDate' AND @OrderBy = 'ASC' THEN inv.ReceivedDate END ASC,
    CASE WHEN @SortBy = 'ReceivedDate' AND @OrderBy = 'DESC' THEN inv.ReceivedDate END DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
