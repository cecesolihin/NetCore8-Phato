SELECT
    EmpWorkExperienceId,
    EmployeeID,
    CONVERT(VARCHAR, StartWorking, 106) AS StartWorking,  -- dd MMM yyyy
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
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate,  -- dd MMM yyyy
    ResignReason

FROM 
    dbo.TEPDEmployeeWorkingExperience
WHERE IsDeleted = 0 AND
    (@EmployeeID IS NULL OR EmployeeID = @EmployeeID) AND
    (@Company IS NULL OR Company LIKE '%' + @Company + '%') AND
    (@EmploymentTypeCode IS NULL OR EmploymentTypeCode LIKE '%' + @EmploymentTypeCode + '%')