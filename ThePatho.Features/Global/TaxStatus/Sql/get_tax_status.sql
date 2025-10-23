DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    TaxStatusCode,
    TaxStatusName,
    Married,
    TotalDependents,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMTaxStatus
WHERE
    IsDeleted = 0 AND
    (@TaxStatusCode IS NULL OR TaxStatusCode LIKE '%' + @TaxStatusCode + '%') AND
    (@TaxStatusName IS NULL OR TaxStatusName LIKE '%' + @TaxStatusName + '%') AND
    (@Married IS NULL OR Married LIKE '%' + @Married + '%') AND
    (@TotalDependents > 0 OR TotalDependents =@TotalDependents)  
ORDER BY
    CASE WHEN @SortBy = 'TaxStatusCode' THEN TaxStatusCode END,
    CASE WHEN @SortBy = 'TaxStatusName' THEN TaxStatusName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;