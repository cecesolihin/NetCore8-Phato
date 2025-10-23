SELECT 
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
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate
FROM 
    dbo.TEPDEmployeeMedical
WHERE
    (@EmployeeId > 0 OR EmployeeID = @EmployeeId) AND
    (@DiseaseName = '' OR DiseaseName LIKE '%' + @DiseaseName + '%') AND
    (@Hospital = '' OR Hospital LIKE '%' + @Hospital + '%') AND
    (IsDeleted = 0 OR IsDeleted IS NULL)

