SELECT 
    LetterTemplateCode,
    LetterTemplateName,
    Content,
    LetterTemplateType,
    LetterCategoryCode,
    Remarks,
    FileUpload,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMLetterTemplate
WHERE
    LetterTemplateCode = @LetterTemplateCode