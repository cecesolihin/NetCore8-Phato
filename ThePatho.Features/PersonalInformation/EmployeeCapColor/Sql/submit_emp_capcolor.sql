IF @Action = 'INSERT'
BEGIN
    INSERT INTO TEPMEmployeeCapColor
    (
        ColorName,
        InsertedBy,
        InsertedDate,
        IsDeleted
    )
    VALUES
    (
        @ColorName,
        @User,
        GETDATE(),
        0
    );
END
ELSE IF @Action = 'UPDATE'
BEGIN
    UPDATE TEPMEmployeeCapColor
    SET
        ColorName = @ColorName,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE
        CapColorId = @CapColorId;
END