IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMRoom
    (
        RoomCode,
        RoomName,
        BuildingCode,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @RoomCode,
        @RoomName,
        @BuildingCode,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMRoom
    SET
        RoomCode = @RoomCode,
        RoomName   = @RoomName,
        BuildingCode   = @BuildingCode,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        RoomCode = @RoomCode;
END	