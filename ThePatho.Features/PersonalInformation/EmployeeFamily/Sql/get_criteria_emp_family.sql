SELECT 
    ef.EmployeeFamilyID,
    ef.EmployeeID,
    ef.RelationCode,
    ef.FamilyName,
    ef.Gender,
    ef.BirthPlace,
    CONVERT(VARCHAR, BirthDate, 106) AS BirthDate,--ef.BirthDate,
    ef.Address,
    ef.Phone,
    ef.BloodTypeCode,
    ef.EduLevelCode,
    ef.MaritalStatusCode,
    ef.DependentStatus,
    ef.EmergencyContact,
    ef.WorkingStatus,
    ef.Company,
    ef.Position,
    ef.KKNo,
    ef.IdentityNo,
    ef.BPJSNo,
    ef.InsuranceName,
    ef.PolisNo,
    ef.Remarks,
    ef.VitalStatus,
    ef.IsDeleted,
    ef.InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,--ef.InsertedDate,
    ef.ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate--ef.ModifiedDate
FROM TEPDEmployeeFamily ef
WHERE ef.IsDeleted = 0
  AND (@EmployeeId > 0 OR ef.EmployeeID = @EmployeeId)
  AND (@RelationCode = '' OR ef.RelationCode = @RelationCode)
  AND (@FamilyName = '' OR ef.FamilyName LIKE '%' + @FamilyName + '%')