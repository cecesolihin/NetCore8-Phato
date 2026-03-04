IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMDocumentType
    (
        DocumentTypeCode,
        DocumentTypeName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @DocumentTypeCode,
        @DocumentTypeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMDocumentType
    SET
        DocumentTypeCode = @DocumentTypeCode,
        DocumentTypeName   = @DocumentTypeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        DocumentTypeCode = @DocumentTypeCode;
END	