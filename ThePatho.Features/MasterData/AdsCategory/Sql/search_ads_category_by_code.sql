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
    @FilterAdsCategoryCode IS NULL OR ads_category_code LIKE '%' + @FilterAdsCategoryCode + '%'