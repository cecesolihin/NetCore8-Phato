DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    BloodTypeCode,
    BloodTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMBloodType
WHERE
    (@BloodTypeCode IS NULL OR BloodTypeCode LIKE '%' + @BloodTypeCode + '%') AND
    (@BloodTypeName IS NULL OR BloodTypeName LIKE '%' + @BloodTypeName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'BloodTypeCode' THEN BloodTypeCode END,
    CASE WHEN @SortBy = 'BloodTypeName' THEN BloodTypeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;