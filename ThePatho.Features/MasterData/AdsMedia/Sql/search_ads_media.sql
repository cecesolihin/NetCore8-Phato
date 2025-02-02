DECLARE @Offset INT = @PageNumber * @PageSize;

SELECT 
    ads_code AS AdsCode,
    ads_name AS AdsName,
    ads_category_code AS AdsCategoryCode,
    phone AS Phone,
    contact_person AS ContactPerson,
    remarks AS Remarks,
    use_recruitment_fee AS UseRecruitmentFee,
    recruitment_fee AS RecruitmentFee,
    inserted_by AS InsertedBy,
    CONVERT(VARCHAR, inserted_date, 120) AS InsertedDate,
    modified_by AS ModifiedBy,
    CONVERT(VARCHAR, modified_date, 120) AS ModifiedDate,
    recruitment_fee_2 AS RecruitmentFee2,
    recruitment_fee_3 AS RecruitmentFee3
FROM 
    dbo.TMAdsMedia
WHERE
    (@AdsCode IS NULL OR ads_code LIKE '%' + @AdsCode + '%') AND
    (@AdsName IS NULL OR ads_name LIKE '%' + @AdsName + '%') AND
    (@AdsCategoryCode IS NULL OR ads_category_code LIKE '%' + @AdsCategoryCode + '%') 
    ORDER BY
    CASE WHEN @SortBy = 'AdsCode' THEN ads_code END,
    CASE WHEN @SortBy = 'AdsName' THEN ads_name END,
    CASE WHEN @SortBy = 'AdsCategoryCode' THEN ads_category_code END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, inserted_date, 120) END
    , CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
      END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;