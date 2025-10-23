SELECT 
    BankCode,
    [Name],
    BranchName,
    CurrencyCode,
    TransferCode,
    TransdferFee,
    SwiftCode,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMBank
WHERE
    BankCode = @BankCode