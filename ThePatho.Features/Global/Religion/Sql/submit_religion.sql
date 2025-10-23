IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMReligion
    (
        ReligionID,
        ReligionName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @ReligionID,
        @ReligionName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMReligion
    SET
        ReligionID = @ReligionID,
        ReligionName   = @ReligionName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        ReligionID = @ReligionID;
END	