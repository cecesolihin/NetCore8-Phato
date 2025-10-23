DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    ClothSizeCode,
    ClothSizeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMClothSize
WHERE
    (@ClothSizeCode IS NULL OR ClothSizeCode LIKE '%' + @ClothSizeCode + '%') AND
    (@ClothSizeName IS NULL OR ClothSizeName LIKE '%' + @ClothSizeName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'ClothSizeCode' THEN ClothSizeCode END,
    CASE WHEN @SortBy = 'ClothSizeName' THEN ClothSizeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;