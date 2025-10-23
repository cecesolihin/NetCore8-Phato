SELECT 
    PunishmentTypeCode,
    PunishmentTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMPunishmentType
WHERE
    (@PunishmentTypeCode IS NULL OR PunishmentTypeCode LIKE '%' + @PunishmentTypeCode + '%') AND
    (@PunishmentTypeName IS NULL OR PunishmentTypeName LIKE '%' + @PunishmentTypeName + '%') 