DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    CurrencyCode,
    CurrencyName,
    Symbol ,
    DecimalDigit ,
    IsDefault ,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMCurrency
WHERE
    (@CurrencyCode IS NULL OR CurrencyCode LIKE '%' + @CurrencyCode + '%') AND
    (@CurrencyName IS NULL OR CurrencyName LIKE '%' + @CurrencyName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'CurrencyCode' THEN CurrencyCode END,
    CASE WHEN @SortBy = 'CurrencyName' THEN CurrencyName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
