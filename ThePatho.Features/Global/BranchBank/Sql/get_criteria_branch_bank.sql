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