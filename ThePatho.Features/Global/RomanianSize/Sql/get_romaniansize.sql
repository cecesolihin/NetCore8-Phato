DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    RomanianSizeId,
    RomanianSizeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMRomanianSize
WHERE
    (@RomanianSizeName IS NULL OR RomanianSizeName LIKE '%' + @RomanianSizeName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'RomanianSizeId' THEN RomanianSizeId END,
    CASE WHEN @SortBy = 'RomanianSizeName' THEN RomanianSizeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;