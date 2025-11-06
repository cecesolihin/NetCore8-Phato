BEGIN TRY
    -- ===== VALIDATION =====
    IF @EmployeeList IS NULL OR LTRIM(RTRIM(@EmployeeList)) = ''
    BEGIN
        SELECT 0 AS Success, 'Employee list is required.' AS Message, NULL AS ErrorNote;
        RETURN;
    END

    IF @EffectiveDate IS NULL
    BEGIN
        SELECT 0 AS Success, 'Effective date is required.' AS Message, NULL AS ErrorNote;
        RETURN;
    END

    -- ===== LOOP THROUGH EMPLOYEE LIST =====
    DECLARE @EmployeeID INT;

    DECLARE cur CURSOR FOR
    SELECT TRY_CAST(value AS INT)
    FROM STRING_SPLIT(@EmployeeList, ',')
    WHERE TRY_CAST(value AS INT) IS NOT NULL;

    OPEN cur;
    FETCH NEXT FROM cur INTO @EmployeeID;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Update record lama yang masih aktif
        UPDATE TEPMSuperiorSubordinate
        SET 
            EndDate = DATEADD(DAY, -1, @EffectiveDate),
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

        FETCH NEXT FROM cur INTO @EmployeeID;
    END

    CLOSE cur;
    DEALLOCATE cur;

    SELECT 1 AS Success, CONCAT(@Action, ' successful.') AS Message, NULL AS ErrorNote;
END TRY
BEGIN CATCH
    SELECT 0 AS Success, 'Unexpected error occurred.' AS Message, ERROR_MESSAGE() AS ErrorNote;
END CATCH;
