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
        @PunishmentType,
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
        PunishmentType = @PunishmentType,
        ValidFrom = @ValidFrom,
        ValidTo = @ValidTo,
        RecoveryDate = @RecoveryDate,
        Remarks = @Remarks,
        Attachment = @Attachment,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmPunishmentID = @EmPunishmentId;
END