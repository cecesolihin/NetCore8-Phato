SELECT 
    CityId,
    CityCode,
    [Name],
    ProvinceId,
    Sort,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMCity
WHERE
    CitiId = @CitiId