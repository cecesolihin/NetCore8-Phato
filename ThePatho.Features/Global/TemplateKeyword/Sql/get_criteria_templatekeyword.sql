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