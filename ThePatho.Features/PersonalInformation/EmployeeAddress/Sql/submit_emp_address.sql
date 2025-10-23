
    UPDATE TEPDEmployeeAddress
    SET
        CompanyCode = @CompanyCode,
        Address = @Address,
        RT = @Rt,
        RW = @Rw,
        SubDistrict = @SubDistrict,
        District = @District,
        CityId = @CityId,
        ProvinceId = @ProvinceId,
        CountryId = @CountryId,
        ZipCode = @ZipCode,
        OwnershipCode = @OwnershipCode,
        CurrAddress = @CurrAddress,
        CurrRT = @CurrRt,
        CurrRW = @CurrRw,
        CurrSubDistrict = @CurrSubDistrict,
        CurrDistrict = @CurrDistrict,
        CurrCityId = @CurrCityId,
        CurrProvinceId = @CurrProvinceId,
        CurrCountryId = @CurrCountryId,
        CurrZipCode = @CurrZipCode,
        CurrOwnershipCode = @CurrOwnershipCode,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE 
        EmployeeID = @EmployeeId;
