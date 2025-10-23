IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TEPDEmployeeMedical
    (
        EmployeeID,
        DiseaseCategoryCode,
        DiseaseName,
        StartDate,
        EndDate,
        Therapy,
        Hospital,
        CountryId,
        ProvinceId,
        CityId,
        Doctor,
        Phone,
        Remarks,
        TimeIn,
        TimeOut,
        Obat,
        TindakanPertama,
        TindakanKedua,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @EmployeeId,
        @DiseaseCategoryCode,
        @DiseaseName,
        @StartDate,
        @EndDate,
        @Therapy,
        @Hospital,
        @CountryId,
        @ProvinceId,
        @CityCode, -- disesuaikan dengan CityId
        @Doctor,
        @Phone,
        @Remarks,
        @TimeIn,
        @TimeOut,
        @Obat,
        @TindakanPertama,
        @TindakanKedua,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TEPDEmployeeMedical
    SET
        DiseaseCategoryCode = @DiseaseCategoryCode,
        DiseaseName = @DiseaseName,
        StartDate = @StartDate,
        EndDate = @EndDate,
        Therapy = @Therapy,
        Hospital = @Hospital,
        CountryId = @CountryId,
        ProvinceId = @ProvinceId,
        CityId = @CityCode,
        Doctor = @Doctor,
        Phone = @Phone,
        Remarks = @Remarks,
        TimeIn = @TimeIn,
        TimeOut = @TimeOut,
        Obat = @Obat,
        TindakanPertama = @TindakanPertama,
        TindakanKedua = @TindakanKedua,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeID = @EmployeeId AND DiseaseName = @DiseaseName;
END
