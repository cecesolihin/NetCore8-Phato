DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    BankCode,
    [Name],
    BranchName,
    CurrencyCode,
    TransferCode,
    TransdferFee,
    SwiftCode,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMBank
WHERE
    (@BankCode IS NULL OR BankCode LIKE '%' + @BankCode + '%') AND
    (@Name IS NULL OR [Name] LIKE '%' + @Name + '%') AND
    (@BranchName IS NULL OR BranchName LIKE '%' + @BranchName + '%') AND
    (@CurrencyCode IS NULL OR CurrencyCode LIKE '%' + @CurrencyCode + '%') AND
    (@SwiftCode IS NULL OR SwiftCode LIKE '%' + @SwiftCode + '%') AND
    (@TransdferFee >= 0 OR TransdferFee = @TransdferFee)
ORDER BY
    CASE WHEN @SortBy = 'BankCode' THEN BankCode END,
    CASE WHEN @SortBy = 'Name' THEN [Name] END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;