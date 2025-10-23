SELECT 
    RelationCode,
    RelationName,
    RelationGender,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMFamilyRelation
WHERE
    RelationCode = @RelationCode