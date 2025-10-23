DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    RelationCode,
    RelationName,
    RelationGender,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMFamilyRelation
WHERE
    (@RelationCode IS NULL OR RelationCode LIKE '%' + @RelationCode + '%') AND
    (@RelationName IS NULL OR RelationName LIKE '%' + @RelationName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'RelationCode' THEN RelationCode END,
    CASE WHEN @SortBy = 'RelationName' THEN RelationName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
