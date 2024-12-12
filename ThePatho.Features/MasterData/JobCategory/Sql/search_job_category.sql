DECLARE @Offset INT = @PageNumber * @PageSize;

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
WHERE
    (@JobCategoryCode IS NULL OR job_category_code LIKE '%' + @JobCategoryCode + '%') AND
    (@JobCategoryName IS NULL OR job_category_name LIKE '%' + @JobCategoryName + '%') 
    ORDER BY
    CASE WHEN @SortBy = 'JobCategoryCode' THEN ads_code END,
    CASE WHEN @SortBy = 'JobCategoryName' THEN ads_name END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, inserted_date, 120) END
    , CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
      END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;