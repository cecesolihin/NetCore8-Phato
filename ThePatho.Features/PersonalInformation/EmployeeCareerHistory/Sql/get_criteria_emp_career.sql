SELECT 
    ech.CareerHistoryNo,
    ech.EmployeeID,
    ech.EmployeeNo,
    emp.Fullname as EmployeeName,
    ech.CompanyCode,
    ech.EmploymentTypeCode,
    ech.ChangeType,
    ech.PositionCode,
    pos.PositionName,
    ech.OrgStructureId,
    ech.JobLevelCode,
   -- ech.JobLevelName,
    ech.JobClassCode,
    ech.GradeCode,
    ech.RankCode,
    ech.CostCenterCode,
    CONVERT(VARCHAR, StartDate, 106) AS StartDate,
    ech.EndDate,
    ech.Remark,
    ech.WorkLocationCode,
    ech.ResignTypeCode,
    ech.TerminationTypeCode,
    ech.PensionTypeCode,
    ech.AssignmentLocation,
    CONVERT(VARCHAR, EffectiveDateTo, 106) AS EffectiveDateTo,
    ech.TaxLocationID,
    ech.IsIncludeSalary,
    ech.EmpSalCompId,
    ech.MutationTypeCode,
    ech.UsePayrollData,
    ech.UseOldJoinDate,
    ech.JoinDate,
    ech.OldEmployeeId,
    ech.Path,
    ech.JabatanId,
    ech.IsEligibleRehire,
    ech.InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ech.ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate
FROM TEPDEmployeeCareerHistory ech
INNER JOIN TEPMEmployee emp 
    ON ech.EmployeeID = emp.EmployeeID
LEFT JOIN TOGMPosition pos 
    ON emp.PositionCode = pos.PositionCode
WHERE 1=1
  AND (@EmployeeId = 0  OR ech.EmployeeID = @EmployeeId)
  AND ((@CareerHistoryNo IS NULL OR @CareerHistoryNo ='') OR ech.CareerHistoryNo like'%' +@CareerHistoryNo +'%')
  AND ((@PositionCode IS NULL OR @PositionCode ='') OR ech.PositionCode LIKE '%'+@PositionCode +'%')
  AND ((@CompanyCode IS NULL OR @CompanyCode = '') OR ech.CompanyCode LIKE '%' + @CompanyCode +'%')
  AND ech.IsDeleted = 0