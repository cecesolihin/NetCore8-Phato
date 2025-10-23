IF @Action = 'ADD'
BEGIN
    INSERT INTO TEPDEmployeeEducation
    (
        EmployeeID, EduLevelCode, Faculty, MajorCode, OtherMajor,
        StartYear, EndYear, GPA, MaxGPA, Institution, [Address],
        CityId, GradTypeCode, CertificateNo, CertificateDate, Remarks,
        IsDeleted, InsertedBy, InsertedDate
    )
    VALUES
    (
        @EmployeeId, @EduLevelCode, @Faculty, @MajorCode, @OtherMajor,
        @StartYear, @EndYear, @Gpa, @MaxGpa, @Institution, @Address,
        @CityCode, @GradTypeCode, @CertificateNo, @CertificateDate, @Remarks,
        0, @User, GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE TEPDEmployeeEducation
    SET
        EduLevelCode = @EduLevelCode,
        Faculty = @Faculty,
        MajorCode = @MajorCode,
        OtherMajor = @OtherMajor,
        StartYear = @StartYear,
        EndYear = @EndYear,
        GPA = @Gpa,
        MaxGPA = @MaxGpa,
        Institution = @Institution,
        Address = @Address,
        CityId = @CityCode,
        GradTypeCode = @GradTypeCode,
        CertificateNo = @CertificateNo,
        CertificateDate = @CertificateDate,
        Remarks = @Remarks,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeEducationID = @EmployeeEducationId;
END
