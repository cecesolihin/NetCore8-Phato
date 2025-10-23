DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    BranchBankCode,
    BranchBankName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMBranchBank
WHERE
    (@BranchBankCode IS NULL OR BranchBankCode LIKE '%' + @BranchBankCode + '%') AND
    (@BranchBankName IS NULL OR BranchBankName LIKE '%' + @BranchBankName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'BranchBankCode' THEN BranchBankCode END,
    CASE WHEN @SortBy = 'BranchBankName' THEN BranchBankName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;