DECLARE @Punishment varchar(150) =(select top 1 tp.PunishmentName from TGEMPunishmentType tp where tp.PunishmentCode = @PunishmentType)
IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TEPDEmployeePunishment
    (
        LetterNo,
        EmployeeID,
        LetterDate,
        PunishmentType,
        ValidFrom,
        ValidTo,
        RecoveryDate,
        Remarks,
        Attachment,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @LetterNo,
        @EmployeeId,
        @LetterDate,
        @Punishment,
        @ValidFrom,
        @ValidTo,
        @RecoveryDate,
        @Remarks,
        @Attachment,
        0, -- default active
        @User,
        GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TEPDEmployeePunishment
    SET
        LetterNo = @LetterNo,
        EmployeeID = @EmployeeId,
        LetterDate = @LetterDate,
        PunishmentType = @Punishment,
        ValidFrom = @ValidFrom,
        ValidTo = @ValidTo,
        RecoveryDate = @RecoveryDate,
        Remarks = @Remarks,
        Attachment = @Attachment,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmPunishmentID = @EmPunishmentId;
END