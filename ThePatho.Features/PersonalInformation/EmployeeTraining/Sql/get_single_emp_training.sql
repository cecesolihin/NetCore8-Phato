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
    EmpTrainingId = @EmpTrainingId;