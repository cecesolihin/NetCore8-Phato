SELECT 
    InsuranceCode,
    InsuranceName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMInsurance
WHERE
    (@InsuranceCode IS NULL OR InsuranceCode LIKE '%' + @InsuranceCode + '%') AND
    (@InsuranceName IS NULL OR InsuranceName LIKE '%' + @InsuranceName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'InsuranceCode' THEN InsuranceCode END,
    CASE WHEN @SortBy = 'InsuranceName' THEN InsuranceName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;