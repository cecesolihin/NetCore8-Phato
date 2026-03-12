DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

DECLARE @SQL NVARCHAR(MAX) = N'
SELECT 
    e.EmployeeID,
    e.EmployeeNo,
    e.Fullname,
    e.Firstname,
    e.MiddleName,
    e.LastName,
    e.CompanyCode,
    c.CompanyName,
    e.PositionCode,
    p.PositionName,
    e.JobClassCode,
    jc.JobClassName,
    e.EmploymentTypeCode,
    et.EmploymentTypeName,
    e.WorkLocationCode,
    wl.WorkLocationName,
    e.CostCenterCode,
    cc.CostCenterName,
    CONVERT(VARCHAR, e.JoinDate, 106) AS JoinDate,
    CONVERT(VARCHAR, e.TerminateDate, 106) AS TerminateDate,
    e.BirthPlace,
    CONVERT(VARCHAR, e.BirthDate, 106) AS BirthDate,
    e.Gender,
    e.TaxType,
    e.TaxStatusCode,
    e.NPWP,
    e.AttendanceID,
    e.NeedReplacement,
    e.IsEligibleRehire,
    e.IsDeleted,
    e.InsertedBy,
    CONVERT(VARCHAR, e.InsertedDate, 106) AS InsertedDate,
    e.ModifiedBy,
    CONVERT(VARCHAR, e.ModifiedDate, 106) AS ModifiedDate,
    pd.NationalityID,
    n.NationalityName,
    pd.ReligionID,
    rlg.ReligionName,
    pd.MaritalStatus,
    CONVERT(VARCHAR, pd.MarriedDate, 106) AS MarriedDate,
    pd.BPJSTK,
    pd.BPJSKES,
    pd.NickName,
    pd.Phone,
    pd.MobilePhone,
    pd.Email,
    pd.BloodType,
    bt.BloodTypeName,
    pd.Height,
    pd.Weight,
    pd.OfficePhone,
    pd.OfficeEmail,
    pd.BuildingCode,
    b.BuildingName,
    pd.RoomCode,
    rm.RoomName,
    pd.PhotoPath
FROM TEPMEmployee e
LEFT JOIN TEPDEmployeePersonalData pd ON e.EmployeeID = pd.EmployeeID
LEFT JOIN TOGMCompanyProfile c ON c.CompanyCode = e.CompanyCode
LEFT JOIN TOGMPosition p ON p.PositionCode = e.PositionCode
LEFT JOIN TOGMJobClass jc ON jc.JobClassCode = e.JobClassCode
LEFT JOIN TOGMEmploymentType et ON et.EmploymentTypeCode = e.EmploymentTypeCode
LEFT JOIN TOGMWorkLocation wl ON wl.WorkLocationCode = e.WorkLocationCode
LEFT JOIN TOGMCostCenter cc ON cc.CostCenterCode = e.CostCenterCode
LEFT JOIN TGEMNationality n ON n.NationalityID = pd.NationalityID
LEFT JOIN TGEMReligion rlg ON rlg.ReligionID = pd.ReligionID
LEFT JOIN TGEMBloodType bt ON bt.BloodTypeCode = pd.BloodType
LEFT JOIN TGEMBuilding b ON b.BuildingCode = pd.BuildingCode
LEFT JOIN TGEMRoom rm ON rm.RoomCode = pd.RoomCode
WHERE e.IsDeleted = 0
';

-- Filter Employee
SET @SQL += N'
AND (
    @Employee IS NULL 
    OR @Employee = ''''
    OR e.EmployeeNo LIKE ''%'' + @Employee + ''%''
    OR e.Fullname LIKE ''%'' + @Employee + ''%''
    OR et.EmploymentTypeCode LIKE ''%'' + @Employee + ''%''
    OR et.EmploymentTypeName LIKE ''%'' + @Employee + ''%''
    OR jc.JobClassCode LIKE ''%'' + @Employee + ''%''
    OR jc.JobClassName LIKE ''%'' + @Employee + ''%''
    OR p.PositionCode LIKE ''%'' + @Employee + ''%''
    OR p.PositionName LIKE ''%'' + @Employee + ''%''
    OR wl.WorkLocationCode LIKE ''%'' + @Employee + ''%''
    OR wl.WorkLocationName LIKE ''%'' + @Employee + ''%''
)';

-- Join Date Filter
SET @SQL += N'
AND (
    @JoinDateFrom IS NULL 
    OR e.JoinDate >= @JoinDateFrom
)';

SET @SQL += N'
AND (
    @JoinDateTo IS NULL 
    OR e.JoinDate <= @JoinDateTo
)';

-- Terminate Date Filter
SET @SQL += N'
AND (
    @TerminateDateFrom IS NULL 
    OR e.TerminateDate >= @TerminateDateFrom
)';

SET @SQL += N'
AND (
    @TerminateDateTo IS NULL 
    OR e.TerminateDate <= @TerminateDateTo
)';

-- Sorting
SET @SQL += N' ORDER BY ' + QUOTENAME(@SortBy) + ' ' + 
CASE WHEN UPPER(@OrderBy) = 'DESC' THEN 'DESC' ELSE 'ASC' END;

-- Paging
SET @SQL += N'
OFFSET ' + CAST(@Offset AS NVARCHAR) + ' ROWS
FETCH NEXT ' + CAST(@PageSize AS NVARCHAR) + ' ROWS ONLY';

EXEC sp_executesql 
    @SQL,
    N'
    @Employee VARCHAR(MAX),
    @JoinDateFrom DATE,
    @JoinDateTo DATE,
    @TerminateDateFrom DATE,
    @TerminateDateTo DATE
    ',
    @Employee,
    @JoinDateFrom,
    @JoinDateTo,
    @TerminateDateFrom,
    @TerminateDateTo;