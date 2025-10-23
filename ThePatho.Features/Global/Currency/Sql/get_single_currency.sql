SELECT 
    CurrencyCode,
    CurrencyName,
    Symbol ,
    DecimalDigit ,
    IsDefault ,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMCurrency
WHERE
    CurrencyCode = @CurrencyCode