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
    (@Name IS NULL OR [Name] LIKE '%' + @Name + '%') 