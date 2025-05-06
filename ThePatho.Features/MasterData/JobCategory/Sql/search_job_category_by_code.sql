SELECT job_category_id as JobCategoryId
      ,job_category_code as JobCategoryCode
      ,job_category_name as JobCategoryName
      ,is_category as IsCategory
      ,parent_category as ParentCategory
      ,inserted_by AS InsertedBy
      ,CONVERT(VARCHAR, inserted_date, 120) AS InsertedDate
      ,modified_by AS ModifiedBy
      ,CONVERT(VARCHAR, modified_date, 120) AS ModifiedDate
  FROM dbo.TMJobCategory
  where job_category_code = @JobCategoryCode 