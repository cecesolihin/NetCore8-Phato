SET @CityCode = NULLIF(LTRIM(RTRIM(@CityCode)), '');
SET @Name     = NULLIF(LTRIM(RTRIM(@Name)), '');

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
FROM dbo.TGEMCity
WHERE
    (@CityCode IS NULL OR CityCode LIKE '%' + @CityCode + '%')
    AND (@Name IS NULL OR [Name] LIKE '%' + @Name + '%')
    AND (@ProvinceId = 0 OR ProvinceId = @ProvinceId);