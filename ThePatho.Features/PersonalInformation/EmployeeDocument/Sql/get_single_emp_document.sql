SELECT 
    ed.EmployeeDocumentId,
    ed.EmployeeID,
    ed.DocumentTypeCode,
    ed.FilePath,
    ed.Remark,
    ed.InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,--ed.InsertedDate,
    ed.ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate--ed.ModifiedDate
FROM TEPDEmployeeDocument ed
WHERE EmployeeDocumentId = @EmployeeDocumentId;