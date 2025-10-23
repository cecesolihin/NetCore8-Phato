SELECT 
    NationalityID,
    NationalityName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMNationality
WHERE
    (@NationalityName IS NULL OR NationalityName LIKE '%' + @NationalityName + '%') 