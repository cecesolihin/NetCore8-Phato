IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMBank
    (
        BankCode,
        [Name],
        BranchName,
        CurrencyCode,
        TransferCode,
        TransdferFee,
        SwiftCode,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @BankCode,
        @Name,
        @BranchName,
        @CurrencyCode,
        @TransferCode,
        @TransdferFee,
        @SwiftCode,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMBank
    SET
        BankCode = @BankCode,
        [Name]   = @Name,
        BranchName      = @BranchName,
        CurrencyCode      = @CurrencyCode,
        TransferCode      = @TransferCode,
        TransdferFee      = @TransdferFee,
        SwiftCode      = @SwiftCode,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        BankCode = @BankCode;
END