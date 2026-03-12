IF EXISTS (
    SELECT 1
    FROM TEPDEmployeePunishment
    WHERE EmployeeID = @EmployeeId
      AND LetterNo = @LetterNo
)
BEGIN
    -- UPDATE
    UPDATE TEPDEmployeePunishment
    SET
        LetterDate = @LetterDate,
        PunishmentType = @PunishmentType,
        ValidFrom = @ValidFrom,
        ValidTo = @ValidTo,
        RecoveryDate = @RecoveryDate,
        Remarks = @Remarks,
        Attachment = @Attachment,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeID = @EmployeeId
      AND LetterNo = @LetterNo;
END
ELSE
BEGIN
    -- INSERT
    INSERT INTO TEPDEmployeePunishment
    (
        EmployeeID,
        LetterNo,
        LetterDate,
        PunishmentType,
        ValidFrom,
        ValidTo,
        RecoveryDate,
        Remarks,
        Attachment,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @EmployeeId,
        @LetterNo,
        @LetterDate,
        @PunishmentType,
        @ValidFrom,
        @ValidTo,
        @RecoveryDate,
        @Remarks,
        @Attachment,
        @User,
        GETDATE()
    );
END