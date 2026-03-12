SELECT 
    PunishmentCode,
    PunishmentName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMPunishmentType
WHERE
    (@PunishmentCode IS NULL OR PunishmentCode LIKE '%' + @PunishmentCode + '%') AND
    (@PunishmentName IS NULL OR PunishmentName LIKE '%' + @PunishmentName + '%') 