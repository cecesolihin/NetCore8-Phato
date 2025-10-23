IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMFamilyRelation
    (
        RelationCode,
        RelationName,
        RelationGender,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @RelationCode,
        @RelationName,
        @RelationGender,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMFamilyRelation
    SET
        RelationCode = @RelationCode,
        RelationName   = @RelationName,
        RelationGender = @RelationGender,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        RelationCode = @RelationCode;
END	
