SELECT 
    EmployeeID,
    DiseaseCategoryCode,
    DiseaseName,
    CONVERT(VARCHAR, StartDate, 106) AS StartDate,--StartDate,
    CONVERT(VARCHAR, EndDate, 106) AS EndDate, --EndDate,
    Therapy,
    Hospital,
    CountryId,
    ProvinceId,
    CityId,
    Doctor,
    Phone,
    Remarks,
    TimeIn,
    [TimeOut],
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
  EmployeeID = @EmployeeId AND
  DiseaseCategoryCode = @DiseaseCategoryCode;
   
