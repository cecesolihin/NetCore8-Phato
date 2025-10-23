SELECT 
    ProfiencyCode,
    ProfiencyName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMSkillProfiency
WHERE
    (@ProfiencyCode IS NULL OR ProfiencyCode LIKE '%' + @ProfiencyCode + '%') AND
    (@ProfiencyName IS NULL OR ProfiencyName LIKE '%' + @ProfiencyName + '%')