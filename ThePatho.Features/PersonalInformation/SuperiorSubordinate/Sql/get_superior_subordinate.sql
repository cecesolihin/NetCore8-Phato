DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
DECLARE @SQL NVARCHAR(MAX) = N'
SELECT 
    t.EmployeeSuperiorID,
    t.EmployeeID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.EmployeeID) AS Employee,
    t.Superior1ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior1ID) AS Superior1,
    t.Superior2ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior2ID) AS Superior2,
    t.Superior3ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior3ID) AS Superior3,
    t.Superior4ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior4ID) AS Superior4,
    t.Superior5ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior5ID) AS Superior5,
    t.Superior6ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior6ID) AS Superior6,
    t.Superior7ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior7ID) AS Superior7,
    t.Superior8ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior8ID) AS Superior8,
    t.Superior9ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior9ID) AS Superior9,
    t.Superior10ID,
    (SELECT TOP 1 CONCAT(e.EmployeeNo, '' '', e.Fullname) FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior10ID) AS Superior10,
    CONVERT(VARCHAR, t.EffectiveDate, 106) AS EffectiveDate,
    CONVERT(VARCHAR, t.EndDate, 106) AS EndDate,
    t.Remarks,
    CASE WHEN t.EndDate IS NULL THEN ''ACTIVE'' ELSE ''ALL'' END AS [Status]
FROM TEPMSuperiorSubordinate t
WHERE 1=1
';


IF @Employee IS NOT NULL AND @Employee <> ''
    SET @SQL += N' AND EXISTS (
        SELECT 1 FROM TEPMEmployee e 
        WHERE e.EmployeeID = t.EmployeeID 
          AND (e.Fullname LIKE ''%'' + @Employee + ''%'' OR e.EmployeeNo LIKE ''%'' + @Employee + ''%'')
    )';

IF @Superior IS NOT NULL AND @Superior <> ''
    SET @SQL += N' AND (
        EXISTS (SELECT 1 FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior1ID AND (e.Fullname LIKE ''%'' + @Superior + ''%'' OR e.EmployeeNo LIKE ''%'' + @Superior + ''%''))
        OR EXISTS (SELECT 1 FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior2ID AND (e.Fullname LIKE ''%'' + @Superior + ''%'' OR e.EmployeeNo LIKE ''%'' + @Superior + ''%''))
        OR EXISTS (SELECT 1 FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior3ID AND (e.Fullname LIKE ''%'' + @Superior + ''%'' OR e.EmployeeNo LIKE ''%'' + @Superior + ''%''))
        OR EXISTS (SELECT 1 FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior4ID AND (e.Fullname LIKE ''%'' + @Superior + ''%'' OR e.EmployeeNo LIKE ''%'' + @Superior + ''%''))
        OR EXISTS (SELECT 1 FROM TEPMEmployee e WHERE e.EmployeeID = t.Superior5ID AND (e.Fullname LIKE ''%'' + @Superior + ''%'' OR e.EmployeeNo LIKE ''%'' + @Superior + ''%''))
    )';

IF @Status IS NOT NULL AND @Status <> ''
BEGIN
    IF UPPER(@Status) = 'ACTIVE'
        SET @SQL += N' AND t.EndDate IS NULL';
    ELSE IF UPPER(@Status) = 'INACTIVE'
        SET @SQL += N' AND t.EndDate IS NOT NULL';
END;

SET @SQL += N' ORDER BY ' + QUOTENAME(@SortBy) + ' ' + 
            CASE WHEN UPPER(@OrderBy) = 'DESC' THEN 'DESC' ELSE 'ASC' END;

SET @SQL += N' OFFSET ' + CAST(@Offset AS NVARCHAR(10)) + 
            N' ROWS FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(10)) + N' ROWS ONLY;';


EXEC sp_executesql
    @SQL,
    N'@Employee VARCHAR(MAX), @Superior VARCHAR(MAX), @Status VARCHAR(MAX)',
    @Employee, @Superior, @Status;