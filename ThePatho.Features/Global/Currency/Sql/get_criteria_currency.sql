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