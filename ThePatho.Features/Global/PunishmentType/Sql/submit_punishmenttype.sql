IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMPunishmentType
    (
        PunishmentCode,
        PunishmentName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @PunishmentTypeCode,
        @PunishmentTypeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMPunishmentType
    SET
        PunishmentCode = @PunishmentCode,
        PunishmentName   = @PunishmentName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        PunishmentCode = @PunishmentCode;
END	