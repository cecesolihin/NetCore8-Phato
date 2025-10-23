IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TEPDEmployeeTraining
    (
        EmployeeID,
        TrainingCourseCode,
        StartDate,
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
        InsertedDate
    )
    VALUES
    (
        @EmployeeId,
        @TrainingCourseCode,
        @StartDate,
        @TrainingTypeCode,
        @TrainingFieldCode,
        @Institution,
        @Address,
        @CityCode,
        @CertificateNo,
        @CertificateDate,
        @EndDate,
        @TrainingPayerCode,
        @CompanyBondDate,
        @Remarks,
        @TrainingBatchCode,
        0, -- Default active
        @User,
        GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TEPDEmployeeTraining
    SET
        EmployeeID = @EmployeeId,
        TrainingCourseCode = @TrainingCourseCode,
        StartDate = @StartDate,
        TrainingTypeCode = @TrainingTypeCode,
        TrainingFieldCode = @TrainingFieldCode,
        Institution = @Institution,
        Address = @Address,
        CityId = @CityCode,
        CertificateNo = @CertificateNo,
        CertificateDate = @CertificateDate,
        EndDate = @EndDate,
        TrainingPayerCode = @TrainingPayerCode,
        CompanyBondDate = @CompanyBondDate,
        Remarks = @Remarks,
        TrainingBatchCode = @TrainingBatchCode,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmpTrainingId = @EmpTrainingId;
END
