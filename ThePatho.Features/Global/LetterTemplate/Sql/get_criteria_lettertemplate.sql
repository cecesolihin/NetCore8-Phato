SELECT 
    LetterTemplateCode,
    LetterTemplateName,
    Content,
    LetterTemplateType,
    LetterCategoryCode,
    Remarks,
    FileUpload,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMLetterTemplate
WHERE
    (@LetterTemplateCode IS NULL OR LetterTemplateCode LIKE '%' + @LetterTemplateCode + '%') AND
    (@LetterTemplateName IS NULL OR LetterTemplateName LIKE '%' + @LetterTemplateName + '%') AND
    (@Content IS NULL OR Content LIKE '%' + Content + '%') AND
    (@LetterTemplateType IS NULL OR LetterTemplateType LIKE '%' + @LetterTemplateType + '%') AND
    (@LetterCategoryCode IS NULL OR LetterCategoryCode LIKE '%' + @LetterCategoryCode + '%') 