IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMTemplateKeyword
    (
        KeywordCode,
        KeywordName,
        [Value],
        StaticValue,
        TableName,
        ColumnName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @KeywordCode,
        @KeywordName,
        @Value,
        @StaticValue,
        @TableName,
        @ColumnName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMTemplateKeyword
    SET
        KeywordCode = @KeywordCode,
        KeywordName   = @KeywordName,
        [Value]      = @Value,
        StaticValue      = @StaticValue,
        TableName      = @TableName,
        ColumnName      = @ColumnName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        KeywordCode = @KeywordCode;
END	