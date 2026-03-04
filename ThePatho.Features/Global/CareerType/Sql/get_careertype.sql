SELECT 
    CareerTypeCode,
    CareerTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMCareerType
WHERE
    (@CareerTypeCode IS NULL OR CareerTypeCode LIKE '%' + @CareerTypeCode + '%') AND
    (@CareerTypeName IS NULL OR CareerTypeName LIKE '%' + @CareerTypeName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'CareerTypeCode' THEN CareerTypeCode END,
    CASE WHEN @SortBy = 'CareerTypeName' THEN CareerTypeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;