SELECT 
    MajorCode,
    MajorName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMEduMajor
WHERE
    (@MajorCode IS NULL OR MajorCode LIKE '%' + @MajorCode + '%') AND
    (@MajorName IS NULL OR MajorName LIKE '%' + @MajorName + '%') 