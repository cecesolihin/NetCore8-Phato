SELECT 
    CityId,
    CityCode,
    [Name],
    ProvinceId,
    Sort,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMCity
WHERE
    (@CityCode IS NULL OR CityCode LIKE '%' + @CityCode + '%') AND
    (@Name IS NULL OR [Name] LIKE '%' + @Name + '%') AND
    (@ProvinceId IS NULL OR ProvinceId = @ProvinceId) 