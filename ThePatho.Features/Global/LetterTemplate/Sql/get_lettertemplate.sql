DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
ORDER BY
    CASE WHEN @SortBy = 'LetterTemplateCode' THEN LetterTemplateCode END,
    CASE WHEN @SortBy = 'LetterTemplateName' THEN LetterTemplateName END,
    CASE WHEN @SortBy = 'Content' THEN Content END,
    CASE WHEN @SortBy = 'LetterTemplateType' THEN LetterTemplateType END,
    CASE WHEN @SortBy = 'LetterCategoryCode' THEN LetterCategoryCode END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;