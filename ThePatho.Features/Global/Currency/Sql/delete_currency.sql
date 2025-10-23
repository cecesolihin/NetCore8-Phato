UPDATE 
    dbo.TGEMCurrency
SET IsDeleted =1
WHERE
    CurrencyCode = @CurrencyCode