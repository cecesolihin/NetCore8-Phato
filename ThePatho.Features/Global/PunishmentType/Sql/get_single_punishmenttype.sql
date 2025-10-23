SELECT 
    PunishmentTypeCode,
    PunishmentTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMPunishmentType
WHERE
    PunishmentTypeCode = @PunishmentTypeCode