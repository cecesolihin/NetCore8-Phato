DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    ech.CareerHistoryNo,
    ech.EmployeeID,
    ech.EmployeeNo,
    ech.CompanyCode,
    ech.EmploymentTypeCode,
    ech.ChangeType,
    ech.PositionCode,
    ech.OrgStructureId,
    ech.JobLevelCode,
    ech.JobClassCode,
    ech.GradeCode,
    ech.RankCode,
    ech.CostCenterCode,
    CONVERT(VARCHAR, StartDate, 106) AS StartDate,--ech.StartDate,
    ech.EndDate,
    ech.Remark,
    ech.WorkLocationCode,
    ech.ResignTypeCode,
    ech.TerminationTypeCode,
    ech.PensionTypeCode,
    ech.AssignmentLocation,
    CONVERT(VARCHAR, EffectiveDateTo, 106) AS EffectiveDateTo,--ech.EffectiveDateTo,
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
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,--ech.InsertedDate,
    ech.ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate--ech.ModifiedDate
FROM TEPDEmployeeCareerHistory ech
WHERE 1=1
  AND (@EmployeeId = 0  OR ech.EmployeeID = @EmployeeId)
  AND ((@CareerHistoryNo IS NULL OR @CareerHistoryNo ='') OR ech.CareerHistoryNo like'%' +@CareerHistoryNo +'%')
  AND ((@PositionCode IS NULL OR @PositionCode ='') OR ech.PositionCode LIKE '%'+@PositionCode +'%')
  AND ((@CompanyCode IS NULL OR @CompanyCode = '') OR ech.CompanyCode LIKE '%' + @CompanyCode +'%')
  AND ech.IsDeleted = 0
ORDER BY
    CASE WHEN @SortBy = 'StartDate' AND @OrderBy = 'ASC' THEN ech.StartDate END ASC,
    CASE WHEN @SortBy = 'StartDate' AND @OrderBy = 'DESC' THEN ech.StartDate END DESC,
    CASE WHEN @SortBy = 'CareerHistoryNo' AND @OrderBy = 'ASC' THEN ech.CareerHistoryNo END ASC,
    CASE WHEN @SortBy = 'CareerHistoryNo' AND @OrderBy = 'DESC' THEN ech.CareerHistoryNo END DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
