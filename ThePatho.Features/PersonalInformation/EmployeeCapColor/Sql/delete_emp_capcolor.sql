UPDATE TEPMEmployeeCapColor
    SET
        IsDeleted = 1,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE
        CapColorId = @CapColorId;