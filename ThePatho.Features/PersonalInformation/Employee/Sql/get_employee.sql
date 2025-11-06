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
    et.EmployementTypeName,
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
  AND ((@EmployeeNo = '''' OR @EmployeeNo IS NULL) OR e.EmployeeNo LIKE ''%'' + @EmployeeNo + ''%'' OR e.Fullname LIKE ''%'' + @EmployeeNo + ''%'')
  AND ((@Fullname = '''' OR @Fullname IS NULL) OR e.Fullname LIKE ''%'' + @Fullname + ''%'')
  AND ((@EmploymentType = '''' OR @EmploymentType IS NULL)
        OR e.EmploymentTypeCode LIKE ''%'' + @EmploymentType + ''%''
        OR et.EmployementTypeName LIKE ''%'' + @EmploymentType + ''%'')
  AND ((@JobClass = '''' OR @JobClass IS NULL)
        OR e.JobClassCode LIKE ''%'' + @JobClass + ''%''
        OR jc.JobClassName LIKE ''%'' + @JobClass + ''%'')
  AND ((@Position = '''' OR @Position IS NULL)
        OR e.PositionCode LIKE ''%'' + @Position + ''%''
        OR p.PositionName LIKE ''%'' + @Position + ''%'')
  AND ((@WorkLocation = '''' OR @WorkLocation IS NULL)
        OR e.WorkLocationCode LIKE ''%'' + @WorkLocation + ''%''
        OR wl.WorkLocationName LIKE ''%'' + @WorkLocation + ''%'')
';


SET @SQL += N' ORDER BY ' + QUOTENAME(@SortBy) + ' ' + CASE WHEN UPPER(@OrderBy) = 'DESC' THEN 'DESC' ELSE 'ASC' END;

SET @SQL += N' OFFSET ' + CAST(@Offset AS NVARCHAR(10)) + ' ROWS FETCH NEXT ' + CAST(@PageSize AS NVARCHAR(10)) + ' ROWS ONLY;';

EXEC sp_executesql 
    @SQL,
    N'@EmployeeNo VARCHAR(MAX), @Fullname VARCHAR(MAX), @EmploymentType VARCHAR(MAX),
      @JobClass VARCHAR(MAX), @Position VARCHAR(MAX), @WorkLocation VARCHAR(MAX)',
    @EmployeeNo, @Fullname, @EmploymentType, @JobClass, @Position, @WorkLocation;