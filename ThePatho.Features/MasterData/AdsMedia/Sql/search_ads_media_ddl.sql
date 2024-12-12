SELECT 
    ads_code AS AdsCode,
    ads_name AS AdsName
FROM 
    dbo.TMAdsMedia
WHERE
    @FilterAdsCategoryCode IS NULL 
    OR ads_category_code LIKE '%' + @FilterAdsCategoryCode + '%';