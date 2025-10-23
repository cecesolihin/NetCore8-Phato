IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMResignReason
    (
        ResignReasonCode,
        ResignReasonName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @ResignReasonCode,
        @ResignReasonName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMResignReason
    SET
        ResignReasonCode = @ResignReasonCode,
        ResignReasonName   = @ResignReasonName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        ResignReasonCode = @ResignReasonCode;
END	