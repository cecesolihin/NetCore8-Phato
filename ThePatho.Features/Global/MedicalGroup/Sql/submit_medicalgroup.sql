IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMMedicalGroup
    (
        MedicalGroupCode,
        MedicalGroupName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @MedicalGroupCode,
        @MedicalGroupName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMMedicalGroup
    SET
        MedicalGroupCode = @MedicalGroupCode,
        MedicalGroupName   = @MedicalGroupName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        MedicalGroupCode = @MedicalGroupCode;
END	