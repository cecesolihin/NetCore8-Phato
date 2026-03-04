

DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

DECLARE @SQL NVARCHAR(MAX) = N'
SELECT 
    t.EmployeeSuperiorID,
    t.EmployeeID,
    emp.EmployeeNo,
    emp.Fullname AS EmployeeName,
    pos.PositionName AS Position,

    CONVERT(VARCHAR, t.EffectiveDate, 106) AS EffectiveDate,
    CONVERT(VARCHAR, t.EndDate, 106) AS EndDate,
    t.Remarks,

    -- Superior 1
    t.Superior1ID,
    s1.EmployeeNo AS Superior1No,
    s1.Fullname AS Superior1Name,
    p1.PositionName AS SuperiorPosition1,

    -- Superior 2
    t.Superior2ID,
    s2.EmployeeNo AS Superior2No,
    s2.Fullname AS Superior2Name,
    p2.PositionName AS SuperiorPosition2,

    -- Superior 3
    t.Superior3ID,
    s3.EmployeeNo AS Superior3No,
    s3.Fullname AS Superior3Name,
    p3.PositionName AS SuperiorPosition3,

    -- Superior 4
    t.Superior4ID,
    s4.EmployeeNo AS Superior4No,
    s4.Fullname AS Superior4Name,
    p4.PositionName AS SuperiorPosition4,

    -- Superior 5
    t.Superior5ID,
    s5.EmployeeNo AS Superior5No,
    s5.Fullname AS Superior5Name,
    p5.PositionName AS SuperiorPosition5,

    -- Superior 6
    t.Superior6ID,
    s6.EmployeeNo AS Superior6No,
    s6.Fullname AS Superior6Name,
    p6.PositionName AS SuperiorPosition6,

    -- Superior 7
    t.Superior7ID,
    s7.EmployeeNo AS Superior7No,
    s7.Fullname AS Superior7Name,
    p7.PositionName AS SuperiorPosition7,

    -- Superior 8
    t.Superior8ID,
    s8.EmployeeNo AS Superior8No,
    s8.Fullname AS Superior8Name,
    p8.PositionName AS SuperiorPosition8,

    -- Superior 9
    t.Superior9ID,
    s9.EmployeeNo AS Superior9No,
    s9.Fullname AS Superior9Name,
    p9.PositionName AS SuperiorPosition9,

    -- Superior 10
    t.Superior10ID,
    s10.EmployeeNo AS Superior10No,
    s10.Fullname AS Superior10Name,
    p10.PositionName AS SuperiorPosition10

FROM TEPMSuperiorSubordinate t

LEFT JOIN TEPMEmployee emp ON t.EmployeeID = emp.EmployeeID
LEFT JOIN TOGMPosition pos ON emp.PositionCode = pos.PositionCode

LEFT JOIN TEPMEmployee s1 ON t.Superior1ID = s1.EmployeeID
LEFT JOIN TOGMPosition p1 ON s1.PositionCode = p1.PositionCode

LEFT JOIN TEPMEmployee s2 ON t.Superior2ID = s2.EmployeeID
LEFT JOIN TOGMPosition p2 ON s2.PositionCode = p2.PositionCode

LEFT JOIN TEPMEmployee s3 ON t.Superior3ID = s3.EmployeeID
LEFT JOIN TOGMPosition p3 ON s3.PositionCode = p3.PositionCode

LEFT JOIN TEPMEmployee s4 ON t.Superior4ID = s4.EmployeeID
LEFT JOIN TOGMPosition p4 ON s4.PositionCode = p4.PositionCode

LEFT JOIN TEPMEmployee s5 ON t.Superior5ID = s5.EmployeeID
LEFT JOIN TOGMPosition p5 ON s5.PositionCode = p5.PositionCode

LEFT JOIN TEPMEmployee s6 ON t.Superior6ID = s6.EmployeeID
LEFT JOIN TOGMPosition p6 ON s6.PositionCode = p6.PositionCode

LEFT JOIN TEPMEmployee s7 ON t.Superior7ID = s7.EmployeeID
LEFT JOIN TOGMPosition p7 ON s7.PositionCode = p7.PositionCode

LEFT JOIN TEPMEmployee s8 ON t.Superior8ID = s8.EmployeeID
LEFT JOIN TOGMPosition p8 ON s8.PositionCode = p8.PositionCode

LEFT JOIN TEPMEmployee s9 ON t.Superior9ID = s9.EmployeeID
LEFT JOIN TOGMPosition p9 ON s9.PositionCode = p9.PositionCode

LEFT JOIN TEPMEmployee s10 ON t.Superior10ID = s10.EmployeeID
LEFT JOIN TOGMPosition p10 ON s10.PositionCode = p10.PositionCode

WHERE 1=1
';

-- FILTER EMPLOYEE & SUPERIOR
IF @Employee IS NOT NULL AND @Employee <> ''
    SET @SQL += N'
    AND (
        emp.Fullname LIKE ''%'' + @Employee + ''%''
        OR emp.EmployeeNo LIKE ''%'' + @Employee + ''%''
        OR pos.PositionName LIKE ''%'' + @Employee + ''%''
    )';

IF @Superior IS NOT NULL AND @Superior <> ''
    SET @SQL += N'
    AND (
        s1.Fullname LIKE ''%'' + @Superior + ''%'' OR s1.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p1.PositionName LIKE ''%'' + @Superior + ''%''
        OR s2.Fullname LIKE ''%'' + @Superior + ''%'' OR s2.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p2.PositionName LIKE ''%'' + @Superior + ''%''
        OR s3.Fullname LIKE ''%'' + @Superior + ''%'' OR s3.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p3.PositionName LIKE ''%'' + @Superior + ''%''
        OR s4.Fullname LIKE ''%'' + @Superior + ''%'' OR s4.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p4.PositionName LIKE ''%'' + @Superior + ''%''
        OR s5.Fullname LIKE ''%'' + @Superior + ''%'' OR s5.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p5.PositionName LIKE ''%'' + @Superior + ''%''
        OR s6.Fullname LIKE ''%'' + @Superior + ''%'' OR s6.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p6.PositionName LIKE ''%'' + @Superior + ''%''
        OR s7.Fullname LIKE ''%'' + @Superior + ''%'' OR s7.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p7.PositionName LIKE ''%'' + @Superior + ''%''
        OR s8.Fullname LIKE ''%'' + @Superior + ''%'' OR s8.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p8.PositionName LIKE ''%'' + @Superior + ''%''
        OR s9.Fullname LIKE ''%'' + @Superior + ''%'' OR s9.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p9.PositionName LIKE ''%'' + @Superior + ''%''
        OR s10.Fullname LIKE ''%'' + @Superior + ''%'' OR s10.EmployeeNo LIKE ''%'' + @Superior + ''%'' OR p10.PositionName LIKE ''%'' + @Superior + ''%''
    )';

-- FILTER EFFECTIVE DATE RANGE
IF @EffectiveDateFrom IS NOT NULL
    SET @SQL += N' AND t.EffectiveDate >= @EffectiveDateFrom';
IF @EffectiveDateTo IS NOT NULL
    SET @SQL += N' AND t.EffectiveDate < DATEADD(DAY,1,@EffectiveDateTo)';

-- SAFE SORT
IF @SortBy NOT IN ('EffectiveDate','EmployeeName','Position')
    SET @SortBy = 'EffectiveDate';

SET @SQL += N'
ORDER BY ' + QUOTENAME(@SortBy) + ' ' +
CASE WHEN UPPER(@OrderBy) = 'DESC' THEN 'DESC' ELSE 'ASC' END;

-- PAGING
SET @SQL += N'
OFFSET ' + CAST(@Offset AS NVARCHAR(10)) + ' ROWS 
FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(10)) + ' ROWS ONLY;';

-- EXECUTE
EXEC sp_executesql
    @SQL,
    N'@Employee NVARCHAR(255),
      @Superior NVARCHAR(255),
      @EffectiveDateFrom DATETIME,
      @EffectiveDateTo DATETIME',
    @Employee,
    @Superior,
    @EffectiveDateFrom,
    @EffectiveDateTo;