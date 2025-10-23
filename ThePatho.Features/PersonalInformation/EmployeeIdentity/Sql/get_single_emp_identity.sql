SELECT 
    EmployeeID,
    IdentityCode,
    CompanyCode,
    IdentityNo,
    CONVERT(VARCHAR, IssuedDate, 106) AS IssuedDate,   -- dd MMM yyyy
    CONVERT(VARCHAR, ExpiredDate, 106) AS ExpiredDate, -- dd MMM yyyy
    Remarks,
    FileName,
    FileFullPath,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate
FROM 
    dbo.TEPDEmployeeIdentity
WHERE
    EmployeeID = @EmployeeId AND
    IdentityCode = @IdentityCode