DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    DiseaseCategoryCode,
    DiseaseCategoryName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMDiseaseCategory
WHERE
    (@DiseaseCategoryCode IS NULL OR DiseaseCategoryCode LIKE '%' + @DiseaseCategoryCode + '%') AND
    (@DiseaseCategoryName IS NULL OR DiseaseCategoryName LIKE '%' + @DiseaseCategoryName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'DiseaseCategoryCode' THEN DiseaseCategoryCode END,
    CASE WHEN @SortBy = 'DiseaseCategoryName' THEN DiseaseCategoryName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
