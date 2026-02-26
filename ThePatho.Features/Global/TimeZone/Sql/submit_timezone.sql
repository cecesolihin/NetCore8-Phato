IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMTimeZone
    (
        TimeZoneCode,
        TimeZoneName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @TimeZoneCode,
        @TimeZoneName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMTimeZone
    SET
        TimeZoneCode = @TimeZoneCode,
        TimeZoneName   = @TimeZoneName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        TimeZoneCode = @TimeZoneCode;
END	