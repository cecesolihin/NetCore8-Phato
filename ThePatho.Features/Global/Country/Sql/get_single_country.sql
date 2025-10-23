SELECT 
    [Name],
    NumericIsoCode,
    ThreeLetterIsoCode,
    TwoLetterIsoCode,
    Sort,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMCountry
WHERE
    CountryId = @CountryId