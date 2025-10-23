DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    KeywordCode,
    KeywordName,
    [Value],
    StaticValue,
    TableName,
    ColumnName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMTemplateKeyword
WHERE
    (@KeywordCode IS NULL OR KeywordCode LIKE '%' + @KeywordCode + '%') AND
    (@KeywordName IS NULL OR KeywordName LIKE '%' + @KeywordName + '%') AND
    (@TableName IS NULL OR TableName LIKE '%' + @TableName + '%') AND
    (@ColumnName IS NULL OR ColumnName LIKE '%' + @ColumnName + '%') AND
    (@Value IS NULL OR [Value] LIKE '%' + @Value + '%') 
ORDER BY
    CASE WHEN @SortBy = 'KeywordCode' THEN KeywordCode END,
    CASE WHEN @SortBy = 'KeywordName' THEN KeywordName END,
    CASE WHEN @SortBy = 'Value' THEN [Value] END,
    CASE WHEN @SortBy = 'StaticValue' THEN StaticValue END,
    CASE WHEN @SortBy = 'TableName' THEN TableName END,
    CASE WHEN @SortBy = 'ColumnName' THEN ColumnName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;