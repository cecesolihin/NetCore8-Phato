IF @Action = 'ADD'
BEGIN
    INSERT INTO TEPDEmployeeFamily
    (
        EmployeeID, RelationCode, FamilyName, Gender, BirthPlace, BirthDate, [Address], Phone,
        BloodTypeCode, EduLevelCode, MaritalStatusCode, DependentStatus, EmergencyContact,
        WorkingStatus, Company, Position, KKNo, IdentityNo, BPJSNo, InsuranceName, PolisNo,
        Remarks, VitalStatus, IsDeleted, InsertedBy, InsertedDate
    )
    VALUES
    (
        @EmployeeId, @RelationCode, @FamilyName, @Gender, @BirthPlace, @BirthDate, @Address, @Phone,
        @BloodTypeCode, @EduLevelCode, @MaritalStatusCode, @DependentStatus, @EmergencyContact,
        @WorkingStatus, @Company, @Position, @KkNo, @IdentityNo, @BpjsNo, @InsuranceName, @PolisNo,
        @Remarks, @VitalStatus, 0, @User, GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE TEPDEmployeeFamily
    SET 
        RelationCode = @RelationCode,
        FamilyName = @FamilyName,
        Gender = @Gender,
        BirthPlace = @BirthPlace,
        BirthDate = @BirthDate,
        Address = @Address,
        Phone = @Phone,
        BloodTypeCode = @BloodTypeCode,
        EduLevelCode = @EduLevelCode,
        MaritalStatusCode = @MaritalStatusCode,
        DependentStatus = @DependentStatus,
        EmergencyContact = @EmergencyContact,
        WorkingStatus = @WorkingStatus,
        Company = @Company,
        Position = @Position,
        KKNo = @KkNo,
        IdentityNo = @IdentityNo,
        BPJSNo = @BpjsNo,
        InsuranceName = @InsuranceName,
        PolisNo = @PolisNo,
        Remarks = @Remarks,
        VitalStatus = @VitalStatus,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeFamilyID = @EmployeeFamilyId;
END

