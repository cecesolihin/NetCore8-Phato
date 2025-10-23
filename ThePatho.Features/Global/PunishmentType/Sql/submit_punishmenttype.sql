IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMPunishmentType
    (
        PunishmentTypeCode,
        PunishmentTypeName,
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
        PunishmentTypeCode = @PunishmentTypeCode,
        PunishmentTypeName   = @PunishmentTypeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        PunishmentTypeCode = @PunishmentTypeCode;
END	