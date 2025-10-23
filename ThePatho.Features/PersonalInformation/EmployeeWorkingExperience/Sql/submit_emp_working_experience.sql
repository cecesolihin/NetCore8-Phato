IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TEPDEmployeeWorkingExperience
    (
        EmployeeID,
        StartWorking,
        EndWorking,
        EmploymentTypeCode,
        Organization,
        Company,
        BusinessField,
        Address,
        CityId,
        JobLevel,
        JobDescription,
        Phone,
        Website,
        ReferenceName,
        ReferencePhone,
        ReferenceEmail,
        CurrencyCode21,
        CurrencyCode15,
        PphA21,
        PphA15,
        Remarks,
        IsDeleted,
        InsertedBy,
        InsertedDate,
        ResignReason
    )
    VALUES
    (
        @EmployeeId,
        @StartWorking,
        @EndWorking,
        @EmploymentTypeCode,
        @Organization,
        @Company,
        @BusinessField,
        @Address,
        @CityId,
        @JobLevel,
        @JobDescription,
        @Phone,
        @Website,
        @ReferenceName,
        @ReferencePhone,
        @ReferenceEmail,
        @CurrencyCode21,
        @CurrencyCode15,
        @PphA21,
        @PphA15,
        @Remarks,
        0,
        @User,
        GETDATE(),
        NULL
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TEPDEmployeeWorkingExperience
    SET
        EmployeeID = @EmployeeId,
        StartWorking = @StartWorking,
        EndWorking = @EndWorking,
        EmploymentTypeCode = @EmploymentTypeCode,
        Organization = @Organization,
        Company = @Company,
        BusinessField = @BusinessField,
        Address = @Address,
        CityId = @CityId,
        JobLevel = @JobLevel,
        JobDescription = @JobDescription,
        Phone = @Phone,
        Website = @Website,
        ReferenceName = @ReferenceName,
        ReferencePhone = @ReferencePhone,
        ReferenceEmail = @ReferenceEmail,
        CurrencyCode21 = @CurrencyCode21,
        CurrencyCode15 = @CurrencyCode15,
        PphA21 = @PphA21,
        PphA15 = @PphA15,
        Remarks = @Remarks,
        ModifiedBy = @User,
        ModifiedDate = GETDATE(),
        ResignReason = @ResignReason
    WHERE EmpWorkExperienceId = @EmpWorkExperienceId;
END
