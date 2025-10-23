SELECT 
    EduLevelCode,
    EduLevelName,
    Sort,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMEduLevel
WHERE
    (@EduLevelCode IS NULL OR EduLevelCode LIKE '%' + @EduLevelCode + '%') AND
    (@EduLevelName IS NULL OR EduLevelName LIKE '%' + @EduLevelName + '%') 