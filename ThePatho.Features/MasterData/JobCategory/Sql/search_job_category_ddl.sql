SELECT job_category_id as JobCategoryId
      ,job_category_code as JobCategoryCode
      ,job_category_name as JobCategoryName
  FROM dbo.TMJobCategory
  where @FilterJobCategoryCode IS NULL 
OR job_category_code LIKE '%' + @FilterJobCategoryCode + '%';