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
@FilterAdsCode IS NULL 
    OR ads_code LIKE '%' + @FilterAdsCode + '%';