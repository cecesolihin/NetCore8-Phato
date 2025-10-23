SELECT 
    LetterCategoryCode,
    LetterCategoryName,
    DocPattern,
    ResetType,
    MappingLetterTemplate,
    SequenceNo,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMLetterCategory
WHERE
    LetterCategoryCode = @LetterCategoryCode