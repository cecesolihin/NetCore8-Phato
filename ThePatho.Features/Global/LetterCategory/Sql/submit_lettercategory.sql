IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMLetterCategory
    (
        LetterCategoryCode,
        LetterCategoryName,
        DocPattern,
        ResetType,
        MappingLetterTemplate,
        SequenceNo,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @LetterCategoryCode,
        @LetterCategoryName,
        @DocPattern,
        @ResetType,
        @MappingLetterTemplate,
        @SequenceNo,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMLetterCategory
    SET
        LetterCategoryCode = @LetterCategoryCode,
        LetterCategoryName   = @LetterCategoryName,
        DocPattern   = @DocPattern,
        ResetType   = @ResetType,
        MappingLetterTemplate   = @MappingLetterTemplate,
        SequenceNo   = @SequenceNo,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        LetterCategoryCode = @LetterCategoryCode;
END