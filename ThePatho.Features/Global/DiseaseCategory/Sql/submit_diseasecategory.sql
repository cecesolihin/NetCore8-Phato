IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMDiseaseCategory
    (
        DiseaseCategoryCode,
        DiseaseCategoryName,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @DiseaseCategoryCode,
        @DiseaseCategoryName,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMDiseaseCategory
    SET
        DiseaseCategoryCode = @DiseaseCategoryCode,
        DiseaseCategoryName   = @DiseaseCategoryName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        DiseaseCategoryCode = @DiseaseCategoryCode;
END	