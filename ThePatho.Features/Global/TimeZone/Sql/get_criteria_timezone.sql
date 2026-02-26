SELECT 
    TimeZoneCode,
    TimeZoneName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMTimeZone
WHERE
    (@TimeZoneCode IS NULL OR TimeZoneCode LIKE '%' + @TimeZoneCode + '%') AND
    (@TimeZoneName IS NULL OR TimeZoneName LIKE '%' + @TimeZoneName + '%') 