DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
ORDER BY
    CASE WHEN @SortBy = 'RewardTypeCode' THEN RewardTypeCode END,
    CASE WHEN @SortBy = 'RewardTypeName' THEN RewardTypeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;