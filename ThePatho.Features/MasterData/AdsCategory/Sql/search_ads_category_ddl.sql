
SELECT 
    ads_category_code AS AdsCategoryCode,
    ads_category_name AS AdsCategoryName

FROM 
    dbo.TMAdsCategory
WHERE
    (@FilterAdsCategoryCode IS NULL OR ads_category_code LIKE '%' + @FilterAdsCategoryCode + '%') AND
    (@FilterAdsCategoryName IS NULL OR ads_category_name LIKE '%' + @FilterAdsCategoryName + '%')


