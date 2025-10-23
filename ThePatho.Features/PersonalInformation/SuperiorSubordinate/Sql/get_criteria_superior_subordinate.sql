SELECT 
    t.EmployeeSuperiorID,
    t.EmployeeID,
    e.EmployeeName,
   -- t.EffectiveDate,
    CONVERT(VARCHAR, t.EffectiveDate, 106) AS EffectiveDate,
   -- t.EndDate,
    CONVERT(VARCHAR, t.EndDate, 106) AS EndDate,
    t.Remarks,
    t.Superior1ID,
    s1.EmployeeName AS Superior1Name,
    CASE 
        WHEN t.EndDate IS NULL THEN 'ACTIVE'
        ELSE 'ALL'
    END AS Status
FROM TEPMSuperiorSubordinate t
LEFT JOIN TEPMEmployee e ON t.EmployeeID = e.EmployeeID
LEFT JOIN TEPMEmployee s1 ON t.Superior1ID = s1.EmployeeID
WHERE
    (@EmployeeId = 0 OR t.EmployeeID = @EmployeeId)
    AND (@EffectiveDate = '' OR CONVERT(varchar(10), t.EffectiveDate, 120) = @EffectiveDate)
    AND (@Superior = '' OR s1.EmployeeName LIKE '%' + @Superior + '%')
    AND (
        @Status = '' 
        OR (@Status = 'ACTIVE' AND t.EndDate IS NULL)
        OR (@Status = 'ALL' AND t.EndDate IS NOT NULL)
    )