DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    t.EmpTrainingId,
    t.EmployeeID,
    t.TrainingCourseCode,
    CONVERT(VARCHAR, t.StartDate, 106) AS StartDate,
    t.TrainingTypeCode,
    t.TrainingFieldCode,
    t.Institution,
    t.Address,
    t.CityId,
    t.CertificateNo,
    t.CertificateDate,
    t.EndDate,
    t.TrainingPayerCode,
    t.CompanyBondDate,
    t.Remarks,
    t.TrainingBatchCode,
    t.IsDeleted,
    t.InsertedBy,
    CONVERT(VARCHAR, t.InsertedDate, 106) AS InsertedDate,
    t.ModifiedBy,
    CONVERT(VARCHAR, t.ModifiedDate, 106) AS ModifiedDate,
    emp.EmployeeNo,
    emp.Fullname AS EmployeeName,
    pos.PositionName
FROM 
    dbo.TEPDEmployeeTraining t
INNER JOIN TEPMEmployee emp 
    ON t.EmployeeID = emp.EmployeeID
LEFT JOIN TOGMPosition pos 
    ON emp.PositionCode = pos.PositionCode
WHERE
    (@EmployeeId = 0 OR t.EmployeeID = @EmployeeId) AND
    (
        @Training IS NULL OR @Training = ''
        OR t.TrainingCourseCode LIKE '%' + @Training + '%'
        OR t.TrainingTypeCode LIKE '%' + @Training + '%'
        OR t.TrainingFieldCode LIKE '%' + @Training + '%') AND
    ISNULL(t.IsDeleted, 0) = 0
ORDER BY
    CASE WHEN @SortBy = 'TrainingCourseCode' THEN t.TrainingCourseCode END,
    CASE WHEN @SortBy = 'TrainingTypeCode' THEN t.TrainingTypeCode END,
    CASE WHEN @SortBy = 'TrainingFieldCode' THEN t.TrainingFieldCode END,
    CASE WHEN @SortBy = 'StartDate' THEN t.StartDate END,
    CASE WHEN @SortBy = 'InsertedDate' THEN t.InsertedDate END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN t.ModifiedDate END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
