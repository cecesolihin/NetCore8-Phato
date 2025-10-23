IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMNationality
    (
        NationalityID,
        NationalityName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @NationalityID,
        @NationalityName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMNationality
    SET
        NationalityID = @NationalityID,
        NationalityName   = @NationalityName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        NationalityID = @NationalityID;
END	