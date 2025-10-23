UPDATE 
    dbo.TGEMBank
SET IsDeleted = 1
WHERE
    BankCode = @BankCode