SELECT 
    ea.EmployeeID,
    ea.CompanyCode,
    ea.Address,
    ea.RT,
    ea.RW,
    ea.SubDistrict,
    ea.District,
    ea.CityId,
    ea.ProvinceId,
    ea.CountryId,
    ea.ZipCode,
    ea.OwnershipCode,
    ea.CurrAddress,
    ea.CurrRT,
    ea.CurrRW,
    ea.CurrSubDistrict,
    ea.CurrDistrict,
    ea.CurrCityId,
    ea.CurrProvinceId,
    ea.CurrCountryId,
    ea.CurrZipCode,
    ea.CurrOwnershipCode,
    ea.IsDeleted,
    ea.InsertedBy,
    ea.InsertedDate,
    ea.ModifiedBy,
    ea.ModifiedDate
FROM 
    TEPDEmployeeAddress ea
WHERE 
    ea.EmployeeID = @EmployeeId
    AND ea.IsDeleted = 0;