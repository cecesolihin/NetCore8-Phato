DECLARE @AdsCategoryCode VARCHAR(30);
DECLARE @AdsCategoryName VARCHAR(30);

SELECT 
    [ads_category_code] AS AdsCategoryCode,
    [ads_category_name] as AdsCategoryName,
    [inserted_by] AS InsertedBy,
    [inserted_date] AS InsertedDate,
    [modified_by] AS ModifiedBy,
    [modified_date] AS ModifiedDate
FROM [dbo].[TMAdsCategory]
WHERE 1 = 1
  AND (NULLIF(@AdsCategoryCode, '') IS NULL OR ads_category_code LIKE '%' + @AdsCategoryCode + '%')
  AND (NULLIF(@AdsCategoryName, '') IS NULL OR ads_category_name LIKE '%' + @AdsCategoryName + '%');
