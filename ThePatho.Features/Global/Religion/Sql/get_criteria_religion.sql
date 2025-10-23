SELECT 
    ReligionID,
    ReligionName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMReligion
WHERE
    (@ReligionName IS NULL OR ReligionName LIKE '%' + @ReligionName + '%')