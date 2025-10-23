SELECT 
     [Name],
    NumericIsoCode,
    ThreeLetterIsoCode,
    TwoLetterIsoCode,
    Sort,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMCountry
WHERE
    (@Name IS NULL OR [Name] LIKE '%' + @Name + '%') AND
    (@NumericIsoCode > 0 OR NumericIsoCode LIKE '%' + @NumericIsoCode + '%') AND
    (@ThreeLetterIsoCode IS NULL OR ThreeLetterIsoCode LIKE '%' + @ThreeLetterIsoCode + '%') AND
    (@TwoLetterIsoCode IS NULL OR TwoLetterIsoCode LIKE '%' + @TwoLetterIsoCode + '%') 
