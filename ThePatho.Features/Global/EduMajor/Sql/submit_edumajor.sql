IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMEduMajor
    (
        MajorCode,
        MajorName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @MajorCode,
        @MajorName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMEduMajor
    SET
        MajorCode = @MajorCode,
        MajorName   = @MajorName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        MajorCode = @MajorCode;
END	