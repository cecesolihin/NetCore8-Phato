DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    LetterCategoryCode,
    LetterCategoryName,
    DocPattern,
    ResetType,
    MappingLetterTemplate,
    SequenceNo,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMLetterCategory
WHERE
    (@LetterCategoryCode IS NULL OR LetterCategoryCode LIKE '%' + @LetterCategoryCode + '%') AND
    (@LetterCategoryName IS NULL OR LetterCategoryName LIKE '%' + @LetterCategoryName + '%') AND
    (@DocPattern IS NULL OR DocPattern LIKE '%' + @DocPattern + '%') AND
    (@ResetType IS NULL OR ResetType LIKE '%' + @ResetType + '%') 
ORDER BY
    CASE WHEN @SortBy = 'LetterCategoryCode' THEN LetterCategoryCode END,
    CASE WHEN @SortBy = 'LetterCategoryName' THEN LetterCategoryName END,
    CASE WHEN @SortBy = 'DocPattern' THEN DocPattern END,
    CASE WHEN @SortBy = 'ResetType' THEN ResetType END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;