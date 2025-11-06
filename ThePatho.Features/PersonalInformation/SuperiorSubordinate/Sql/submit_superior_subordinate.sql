IF @Action = 'ADD'
BEGIN
    -- Update record lama yang masih aktif
    UPDATE TEPMSuperiorSubordinate
    SET EndDate = DATEADD(DAY, -1, @EffectiveDate),
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeID = @EmployeeID
      AND EndDate IS NULL;

    -- Insert data baru
    INSERT INTO TEPMSuperiorSubordinate
    (
        EmployeeID,
        EffectiveDate,
        EndDate,
        Remarks,
        Superior1ID, Superior2ID, Superior3ID, Superior4ID, Superior5ID,
        Superior6ID, Superior7ID, Superior8ID, Superior9ID, Superior10ID,
        InsertedBy, InsertedDate
    )
    VALUES
    (
        @EmployeeID,
        @EffectiveDate,
        null,
        @Remarks,
        @Superior1ID, @Superior2ID, @Superior3ID, @Superior4ID, @Superior5ID,
        @Superior6ID, @Superior7ID, @Superior8ID, @Superior9ID, @Superior10ID,
        @User, GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    -- Tidak boleh ubah EffectiveDate
    UPDATE TEPMSuperiorSubordinate
    SET 
        Remarks = @Remarks,
        Superior1ID = @Superior1ID,
        Superior2ID = @Superior2ID,
        Superior3ID = @Superior3ID,
        Superior4ID = @Superior4ID,
        Superior5ID = @Superior5ID,
        Superior6ID = @Superior6ID,
        Superior7ID = @Superior7ID,
        Superior8ID = @Superior8ID,
        Superior9ID = @Superior9ID,
        Superior10ID = @Superior10ID,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeSuperiorID = @EmployeeSuperiorID;
END
