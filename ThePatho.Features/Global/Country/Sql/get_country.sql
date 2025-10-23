DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
ORDER BY
    CASE WHEN @SortBy = 'BloodTypeCode' THEN BloodTypeCode END,
    CASE WHEN @SortBy = 'BloodTypeName' THEN BloodTypeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;