SELECT 
    RewardTypeCode,
    RewardTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMRewardType
WHERE
    (@RewardTypeCode IS NULL OR RewardTypeCode LIKE '%' + @RewardTypeCode + '%') AND
    (@RewardTypeName IS NULL OR RewardTypeName LIKE '%' + @RewardTypeName + '%')