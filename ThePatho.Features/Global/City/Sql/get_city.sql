DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
ORDER BY
    CASE WHEN @SortBy = 'CityCode' THEN CityCode END,
    CASE WHEN @SortBy = 'Name' THEN Name END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
