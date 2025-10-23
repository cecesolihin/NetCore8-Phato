DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
ORDER BY
    CASE WHEN @SortBy = 'Abbreviation' THEN Abbreviation END,
    CASE WHEN @SortBy = 'ProvinceId' THEN ProvinceId END,
    CASE WHEN @SortBy = 'CountryId' THEN CountryId END,
    CASE WHEN @SortBy = 'Sort' THEN Sort END,
    CASE WHEN @SortBy = 'Name' THEN [Name] END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;