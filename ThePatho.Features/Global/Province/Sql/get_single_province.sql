SELECT 
    ProvinceId ,
    Abbreviation ,
    CountryId ,
    Sort ,
    [Name],
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMProvince
WHERE
    ProvinceId = @ProvinceId