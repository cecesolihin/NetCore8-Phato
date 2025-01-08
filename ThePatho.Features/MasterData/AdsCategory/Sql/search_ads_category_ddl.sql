
SELECT 
    ads_category_code AS AdsCategoryCode,
    ads_category_name AS AdsCategoryName

FROM 
    dbo.TMAdsCategory
WHERE
    (@AdsCategoryCode IS NULL OR ads_category_code LIKE '%' + @AdsCategoryCode + '%') AND
    (@AdsCategoryName IS NULL OR ads_category_name LIKE '%' + @AdsCategoryName + '%')


