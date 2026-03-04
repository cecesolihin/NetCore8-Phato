DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
  AND (@EmployeeId = 0 OR ech.EmployeeID = @EmployeeId)
  AND (
        @CareerHistory IS NULL 
        OR @CareerHistory = ''
        OR ech.CareerHistoryNo LIKE '%' + @CareerHistory + '%'
        OR ech.PositionCode LIKE '%' + @CareerHistory + '%'
        OR ech.CompanyCode LIKE '%' + @CareerHistory + '%'
        OR ech.ChangeType LIKE '%' + @CareerHistory + '%'
      )
   AND (
        @EffectiveDateFrom IS NULL 
        OR ech.StartDate >= @EffectiveDateFrom
    )

    AND (
        @EffectiveDateTo IS NULL 
        OR ech.StartDate <= @EffectiveDateTo
    )
  AND ech.IsDeleted = 0
ORDER BY
    CASE WHEN @SortBy = 'StartDate' AND @OrderBy = 'ASC' THEN ech.StartDate END ASC,
    CASE WHEN @SortBy = 'StartDate' AND @OrderBy = 'DESC' THEN ech.StartDate END DESC,
    CASE WHEN @SortBy = 'CareerHistoryNo' AND @OrderBy = 'ASC' THEN ech.CareerHistoryNo END ASC,
    CASE WHEN @SortBy = 'CareerHistoryNo' AND @OrderBy = 'DESC' THEN ech.CareerHistoryNo END DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
