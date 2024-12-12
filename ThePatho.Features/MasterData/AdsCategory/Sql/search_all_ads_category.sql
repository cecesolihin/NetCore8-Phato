DECLARE @Offset INT = @PageNumber * @PageSize;

SELECT 
    ads_category_code AS AdsCategoryCode,
    ads_category_name AS AdsCategoryName,
    inserted_by AS InsertedBy,
    CONVERT(VARCHAR, inserted_date, 120) AS InsertedDate,
    modified_by AS ModifiedBy,
    CONVERT(VARCHAR, modified_date, 120) AS ModifiedDate

FROM 
    dbo.TMAdsCategory
WHERE
    (@FilterAdsCategoryCode IS NULL OR ads_category_code LIKE '%' + @FilterAdsCategoryCode + '%') AND
    (@FilterAdsCategoryName IS NULL OR ads_category_name LIKE '%' + @FilterAdsCategoryName + '%')
ORDER BY
    CASE WHEN @SortBy = 'AdsCategoryCode' THEN ads_category_code END,
    CASE WHEN @SortBy = 'AdsCategoryName' THEN ads_category_name END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, inserted_date, 120) END
    , CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
      END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;


