IF @Action = 'ADD'
BEGIN
    INSERT INTO TEPDEmployeeDocument
    (
        EmployeeID,
        DocumentTypeCode,
        FilePath,
        Remark,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @EmployeeId,
        @DocumentTypeCode,
        @FilePath,
        @Remark,
        @User,
        GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE TEPDEmployeeDocument
    SET 
        DocumentTypeCode = @DocumentTypeCode,
        FilePath = @FilePath,
        Remark = @Remark,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeDocumentId = @EmployeeDocumentId;
END
