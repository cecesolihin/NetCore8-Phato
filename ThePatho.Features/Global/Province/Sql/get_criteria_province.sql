SELECT 
    ProvinceId ,
    Abbreviation ,
    CountryId ,
    Sort ,
    [Name],
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMProvince
WHERE
    (@Abbreviation IS NULL OR Abbreviation LIKE '%' + @Abbreviation + '%') AND
    (@Name IS NULL OR [Name] LIKE '%' + @Name + '%') AND
    (@CountryId > 0 OR CountryId =@CountryId) 