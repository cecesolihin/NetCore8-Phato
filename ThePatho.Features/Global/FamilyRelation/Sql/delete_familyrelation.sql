UPDATE 
    dbo.TGEMFamilyRelation
SET IsDeleted = 1
WHERE
    RelationCode = @RelationCode