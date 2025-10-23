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