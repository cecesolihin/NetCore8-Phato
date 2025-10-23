IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMCity
    (
        CityCode,
        [Name],
        ProvinceId,
        Sort,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @CityCode,
        @Name,
        @ProvinceId,
        @Sort,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMCity
    SET
        CityCode = @CityCode,
        [Name]   = @Name,
        ProvinceId = @ProvinceId,
        Sort = @Sort,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        CityId = @CityId;
END	