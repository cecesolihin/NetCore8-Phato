DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    EmpTrainingId,
    EmployeeID,
    TrainingCourseCode,
    CONVERT(VARCHAR, StartDate, 106) AS StartDate,  -- dd MMM yyyy,
    TrainingTypeCode,
    TrainingFieldCode,
    Institution,
    Address,
    CityId,
    CertificateNo,
    CertificateDate,
    EndDate,
    TrainingPayerCode,
    CompanyBondDate,
    Remarks,
    TrainingBatchCode,
    IsDeleted,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate   -- dd MMM yyyy
FROM 
    dbo.TEPDEmployeeTraining
WHERE
    (@EmployeeId = 0 OR EmployeeID = @EmployeeId) AND
    (@TrainingCourseCode IS NULL OR TrainingCourseCode LIKE '%' + @TrainingCourseCode + '%') AND
    (@TrainingTypeCode IS NULL OR TrainingTypeCode LIKE '%' + @TrainingTypeCode + '%') AND
    (@TrainingFieldCode IS NULL OR TrainingFieldCode LIKE '%' + @TrainingFieldCode + '%') AND
    IsDeleted = 0
ORDER BY
    CASE WHEN @SortBy = 'TrainingCourseCode' THEN TrainingCourseCode END,
    CASE WHEN @SortBy = 'TrainingTypeCode' THEN TrainingTypeCode END,
    CASE WHEN @SortBy = 'TrainingFieldCode' THEN TrainingFieldCode END,
    CASE WHEN @SortBy = 'StartDate' THEN StartDate END,
    CASE WHEN @SortBy = 'InsertedDate' THEN InsertedDate END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN ModifiedDate END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
