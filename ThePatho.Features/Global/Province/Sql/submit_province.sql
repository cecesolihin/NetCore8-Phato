IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMProvince
    (
        Abbreviation ,
        CountryId ,
        Sort ,
        IsDeleted ,
        [Name],
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @Abbreviation ,
        @CountryId ,
        @Sort ,
        0 ,
        @Name,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMProvince
    SET
        Abbreviation = @Abbreviation,
        CountryId   = @CountryId,
        Sort   = @Sort,
        CountryId   = @CountryId,
        [Name]   = @Name,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        ProvinceId = @ProvinceId;
END