IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMRadiusUnit
    (
        RadiusUnitCode,
        RadiusUnitName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @RadiusUnitCode,
        @RadiusUnitName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMRadiusUnit
    SET
        RadiusUnitCode = @RadiusUnitCode,
        RadiusUnitName   = @RadiusUnitName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        RadiusUnitCode = @RadiusUnitCode;
END	