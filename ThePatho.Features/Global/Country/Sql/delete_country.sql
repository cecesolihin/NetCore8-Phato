UPDATE 
    dbo.TGEMCountry
SET IsDeted = 1
WHERE
    CountryId = @CountryId