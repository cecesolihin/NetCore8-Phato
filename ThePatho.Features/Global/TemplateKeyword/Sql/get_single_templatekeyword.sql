SELECT 
    KeywordCode,
    KeywordName,
    [Value],
    StaticValue,
    TableName,
    ColumnName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMTemplateKeyword
WHERE
    KeywordCode = @KeywordCode