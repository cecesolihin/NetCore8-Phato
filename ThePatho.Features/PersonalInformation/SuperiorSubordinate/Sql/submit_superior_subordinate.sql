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
        Superior11ID, Superior12ID, Superior13ID, Superior14ID, Superior15ID,
        Superior16ID, Superior17ID, Superior18ID, Superior19ID, Superior20ID,
        Superior21ID, Superior22ID, Superior23ID, Superior24ID, Superior25ID,
        Superior26ID, Superior27ID, Superior28ID, Superior29ID, Superior30ID,
        InsertedBy, InsertedDate
    )
    VALUES
    (
        @EmployeeID,
        @EffectiveDate,
        @EndDate,
        @Remarks,
        @Superior1ID, @Superior2ID, @Superior3ID, @Superior4ID, @Superior5ID,
        @Superior6ID, @Superior7ID, @Superior8ID, @Superior9ID, @Superior10ID,
        @Superior11ID, @Superior12ID, @Superior13ID, @Superior14ID, @Superior15ID,
        @Superior16ID, @Superior17ID, @Superior18ID, @Superior19ID, @Superior20ID,
        @Superior21ID, @Superior22ID, @Superior23ID, @Superior24ID, @Superior25ID,
        @Superior26ID, @Superior27ID, @Superior28ID, @Superior29ID, @Superior30ID,
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
        Superior11ID = @Superior11ID,
        Superior12ID = @Superior12ID,
        Superior13ID = @Superior13ID,
        Superior14ID = @Superior14ID,
        Superior15ID = @Superior15ID,
        Superior16ID = @Superior16ID,
        Superior17ID = @Superior17ID,
        Superior18ID = @Superior18ID,
        Superior19ID = @Superior19ID,
        Superior20ID = @Superior20ID,
        Superior21ID = @Superior21ID,
        Superior22ID = @Superior22ID,
        Superior23ID = @Superior23ID,
        Superior24ID = @Superior24ID,
        Superior25ID = @Superior25ID,
        Superior26ID = @Superior26ID,
        Superior27ID = @Superior27ID,
        Superior28ID = @Superior28ID,
        Superior29ID = @Superior29ID,
        Superior30ID = @Superior30ID,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeSuperiorID = @EmployeeSuperiorID;
END
