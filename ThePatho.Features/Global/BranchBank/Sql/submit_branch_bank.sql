IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMBranchBank
    (
        BranchBankCode,
        BranchBankName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @BranchBankCode,
        @BranchBankName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMBranchBank
    SET
        BranchBankCode = @BranchBankCode,
        BranchBankName   = @BranchBankName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        BranchBankCode = @BranchBankCode;
END