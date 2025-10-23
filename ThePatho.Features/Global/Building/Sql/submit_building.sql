IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMBuilding
    (
        BuildingCode,
        BuildingName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @BuildingCode,
        @BuildingName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMBuilding
    SET
        BuildingCode = @BuildingCode,
        BuildingName   = @BuildingName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        BuildingCode = @BuildingCode;
END	