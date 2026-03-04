SELECT 
    DocumentTypeCode,
    DocumentTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMDocumentType
WHERE
    (@DocumentTypeCode IS NULL OR DocumentTypeCode LIKE '%' + @DocumentTypeCode + '%') AND
    (@DocumentTypeName IS NULL OR DocumentTypeName LIKE '%' + @DocumentTypeName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'DocumentTypeCode' THEN DocumentTypeCode END,
    CASE WHEN @SortBy = 'DocumentTypeName' THEN DocumentTypeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;