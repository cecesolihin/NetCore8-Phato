SELECT 
    RelationCode,
    RelationName,
    RelationGender,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMFamilyRelation
WHERE
    (@RelationCode IS NULL OR RelationCode LIKE '%' + @RelationCode + '%') AND
    (@RelationName IS NULL OR RelationName LIKE '%' + @RelationName + '%') 