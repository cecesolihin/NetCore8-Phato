IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMLetterTemplate
    (
        LetterTemplateCode,
        LetterTemplateName,
        Content,
        LetterTemplateType,
        LetterCategoryCode,
        Remarks,
        FileUpload,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @LetterTemplateCode,
        @LetterTemplateName,
        @Content,
        @LetterTemplateType,
        @LetterCategoryCode,
        @Remarks,
        @FileUpload,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMLetterTemplate
    SET
        LetterTemplateCode = @LetterTemplateCode,
        LetterTemplateName   = @LetterTemplateName,
        Content   = @Content,
        LetterTemplateType   = @LetterTemplateType,
        Remarks   = @LetterCategoryCode,
        FileUpload   = @Remarks,
        FileUpload   = @FileUpload,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        LetterTemplateCode = @LetterTemplateCode;
END	