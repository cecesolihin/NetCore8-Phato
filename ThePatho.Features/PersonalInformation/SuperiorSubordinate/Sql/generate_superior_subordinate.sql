BEGIN TRY
    --DECLARE @EmployeeList VARCHAR(MAX) = '11';
    --DECLARE @OverWrite BIT = 1;
    --DECLARE @EffectiveDate DATETIME = GETDATE();
    --DECLARE @Remarks VARCHAR(MAX) = 'test query';
    --DECLARE @User VARCHAR(MAX) = 'admin';

    -- Variabel untuk cursor
    DECLARE @EmployeeID INT,
            @Superior1ID INT,
            @Superior2ID INT,
            @Superior3ID INT,
            @Superior4ID INT,
            @Superior5ID INT,
            @Superior6ID INT,
            @Superior7ID INT,
            @Superior8ID INT,
            @Superior9ID INT,
            @Superior10ID INT;

    -- Buat temporary table untuk menyimpan hasil
    DECLARE @SuperiorData AS TABLE
    (
        EmployeeID INT,
        Superior1ID INT,
        Superior2ID INT,
        Superior3ID INT,
        Superior4ID INT,
        Superior5ID INT,
        Superior6ID INT,
        Superior7ID INT,
        Superior8ID INT,
        Superior9ID INT,
        Superior10ID INT
    );

    ;WITH EmployeeData AS (
        SELECT 
            emp.EmployeeID,
            emp.EmployeeNo,
            emp.Fullname,
            pos.ActAsHead,
            pos.PositionCode,
            pos.PositionName,
            org.OrgStructureID,
            org.OrgStructureName,
            emp.JoinDate,
            org.ParentOrgStructureID,
            jl.Sort AS JobLevelSort
        FROM TEPMEmployee AS emp
        INNER JOIN TOGMPosition AS pos ON emp.PositionCode = pos.PositionCode
        INNER JOIN TOGMOrgStructure AS org ON pos.OrgStructureID = org.OrgStructureID
        INNER JOIN TOGMJobLevel AS jl ON pos.JobLevelCode = jl.JobLevelCode
        WHERE emp.IsDeleted = 0
          AND (emp.TerminateDate IS NULL OR emp.TerminateDate >= CAST(GETDATE() AS DATE))
    ),
    EmployeeHierarchy AS (
        SELECT 
            e.EmployeeID,
            e.OrgStructureID AS Level1Org,
            os1.ParentOrgStructureID AS Level2Org,
            os2.ParentOrgStructureID AS Level3Org,
            os3.ParentOrgStructureID AS Level4Org,
            os4.ParentOrgStructureID AS Level5Org,
            os5.ParentOrgStructureID AS Level6Org,
            os6.ParentOrgStructureID AS Level7Org,
            os7.ParentOrgStructureID AS Level8Org,
            os8.ParentOrgStructureID AS Level9Org,
            os9.ParentOrgStructureID AS Level10Org
        FROM EmployeeData e
        LEFT JOIN TOGMOrgStructure os1 ON e.OrgStructureID = os1.OrgStructureID
        LEFT JOIN TOGMOrgStructure os2 ON os1.ParentOrgStructureID = os2.OrgStructureID
        LEFT JOIN TOGMOrgStructure os3 ON os2.ParentOrgStructureID = os3.OrgStructureID
        LEFT JOIN TOGMOrgStructure os4 ON os3.ParentOrgStructureID = os4.OrgStructureID
        LEFT JOIN TOGMOrgStructure os5 ON os4.ParentOrgStructureID = os5.OrgStructureID
        LEFT JOIN TOGMOrgStructure os6 ON os5.ParentOrgStructureID = os6.OrgStructureID
        LEFT JOIN TOGMOrgStructure os7 ON os6.ParentOrgStructureID = os7.OrgStructureID
        LEFT JOIN TOGMOrgStructure os8 ON os7.ParentOrgStructureID = os8.OrgStructureID
        LEFT JOIN TOGMOrgStructure os9 ON os8.ParentOrgStructureID = os9.OrgStructureID
    )
    INSERT INTO @SuperiorData
    SELECT 
        eh.EmployeeID,
        (SELECT TOP 1 ed1.EmployeeID FROM EmployeeData ed1 
         WHERE ed1.OrgStructureID = eh.Level1Org AND ed1.ActAsHead = 1 
         ORDER BY ed1.JoinDate ASC) AS Superior1ID,
        (SELECT TOP 1 ed2.EmployeeID FROM EmployeeData ed2 
         WHERE ed2.OrgStructureID = eh.Level2Org AND ed2.ActAsHead = 1 
         ORDER BY ed2.JoinDate ASC) AS Superior2ID,
        (SELECT TOP 1 ed3.EmployeeID FROM EmployeeData ed3 
         WHERE ed3.OrgStructureID = eh.Level3Org AND ed3.ActAsHead = 1 
         ORDER BY ed3.JoinDate ASC) AS Superior3ID,
        (SELECT TOP 1 ed4.EmployeeID FROM EmployeeData ed4 
         WHERE ed4.OrgStructureID = eh.Level4Org AND ed4.ActAsHead = 1 
         ORDER BY ed4.JoinDate ASC) AS Superior4ID,
        (SELECT TOP 1 ed5.EmployeeID FROM EmployeeData ed5 
         WHERE ed5.OrgStructureID = eh.Level5Org AND ed5.ActAsHead = 1 
         ORDER BY ed5.JoinDate ASC) AS Superior5ID,
        (SELECT TOP 1 ed6.EmployeeID FROM EmployeeData ed6 
         WHERE ed6.OrgStructureID = eh.Level6Org AND ed6.ActAsHead = 1 
         ORDER BY ed6.JoinDate ASC) AS Superior6ID,
        (SELECT TOP 1 ed7.EmployeeID FROM EmployeeData ed7 
         WHERE ed7.OrgStructureID = eh.Level7Org AND ed7.ActAsHead = 1 
         ORDER BY ed7.JoinDate ASC) AS Superior7ID,
        (SELECT TOP 1 ed8.EmployeeID FROM EmployeeData ed8 
         WHERE ed8.OrgStructureID = eh.Level8Org AND ed8.ActAsHead = 1 
         ORDER BY ed8.JoinDate ASC) AS Superior8ID,
        (SELECT TOP 1 ed9.EmployeeID FROM EmployeeData ed9 
         WHERE ed9.OrgStructureID = eh.Level9Org AND ed9.ActAsHead = 1 
         ORDER BY ed9.JoinDate ASC) AS Superior9ID,
        (SELECT TOP 1 ed10.EmployeeID FROM EmployeeData ed10 
         WHERE ed10.OrgStructureID = eh.Level10Org AND ed10.ActAsHead = 1 
         ORDER BY ed10.JoinDate ASC) AS Superior10ID
    FROM EmployeeHierarchy eh
    WHERE eh.EmployeeID IN (SELECT TRY_CAST(value AS INT) FROM STRING_SPLIT(@EmployeeList, ','));

    -- Cursor untuk proses insert/update
    DECLARE employee_cursor CURSOR LOCAL FAST_FORWARD FOR
    SELECT EmployeeID, Superior1ID, Superior2ID, Superior3ID, Superior4ID,
           Superior5ID, Superior6ID, Superior7ID, Superior8ID, Superior9ID, Superior10ID
    FROM @SuperiorData;

    OPEN employee_cursor;

    FETCH NEXT FROM employee_cursor 
    INTO @EmployeeID, @Superior1ID, @Superior2ID, @Superior3ID, @Superior4ID, 
         @Superior5ID, @Superior6ID, @Superior7ID, @Superior8ID, @Superior9ID, @Superior10ID;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @LastDataExists BIT = 0;
        DECLARE @EmployeeSuperiorID INT = 0;

        SET @EmployeeSuperiorID = ISNULL((
            SELECT TOP 1 EmployeeSuperiorID 
            FROM TEPMSuperiorSubordinate 
            WHERE EndDate IS NULL AND EmployeeID = @EmployeeID 
              AND EffectiveDate <= GETDATE()
        ),0);

        IF @EmployeeSuperiorID > 0 SET @LastDataExists = 1;

        IF @IsOverWrite = 1
        BEGIN
            IF @LastDataExists = 1
            BEGIN
                UPDATE TEPMSuperiorSubordinate
                SET EndDate = DATEADD(DAY, -1, @EffectiveDate),
                    ModifiedBy = @User,
                    ModifiedDate = GETDATE()
                WHERE EmployeeSuperiorID = @EmployeeSuperiorID;
            END

            INSERT INTO TEPMSuperiorSubordinate
            (
                EmployeeID, EffectiveDate, EndDate, Remarks,
                Superior1ID, Superior2ID, Superior3ID, Superior4ID, Superior5ID,
                Superior6ID, Superior7ID, Superior8ID, Superior9ID, Superior10ID,
                Superior11ID, Superior12ID, Superior13ID, Superior14ID, Superior15ID,
                Superior16ID, Superior17ID, Superior18ID, Superior19ID, Superior20ID,
                Superior21ID, Superior22ID, Superior23ID, Superior24ID, Superior25ID,
                Superior26ID, Superior27ID, Superior28ID, Superior29ID, Superior30ID,
                InsertedBy, InsertedDate, ModifiedBy, ModifiedDate
            )
            VALUES
            (
                @EmployeeID, @EffectiveDate, NULL, @Remarks,
                @Superior1ID, @Superior2ID, @Superior3ID, @Superior4ID, @Superior5ID,
                @Superior6ID, @Superior7ID, @Superior8ID, @Superior9ID, @Superior10ID,
                NULL,NULL,NULL,NULL,NULL,
                NULL,NULL,NULL,NULL,NULL,
                NULL,NULL,NULL,NULL,NULL,
                NULL,NULL,NULL,NULL,NULL,
                @User, GETDATE(), NULL, NULL
            );
        END
        ELSE
        BEGIN
            IF NOT EXISTS (
                SELECT 1 FROM TEPMSuperiorSubordinate
                WHERE EndDate IS NULL AND EmployeeID = @EmployeeID 
                  AND EffectiveDate <= GETDATE()
            )
            BEGIN
                INSERT INTO TEPMSuperiorSubordinate
                (
                    EmployeeID, EffectiveDate, EndDate, Remarks,
                    Superior1ID,Superior2ID,Superior3ID,Superior4ID,Superior5ID,
                    Superior6ID,Superior7ID,Superior8ID,Superior9ID,Superior10ID,
                    InsertedBy,InsertedDate
                )
                VALUES
                (
                    @EmployeeID, @EffectiveDate, NULL, @Remarks,
                    @Superior1ID,@Superior2ID,@Superior3ID,@Superior4ID,@Superior5ID,
                    @Superior6ID,@Superior7ID,@Superior8ID,@Superior9ID,@Superior10ID,
                    @User, GETDATE()
                );
            END
        END

        FETCH NEXT FROM employee_cursor 
        INTO @EmployeeID, @Superior1ID, @Superior2ID, @Superior3ID, @Superior4ID, 
             @Superior5ID, @Superior6ID, @Superior7ID, @Superior8ID, @Superior9ID, @Superior10ID;
    END

    CLOSE employee_cursor;
    DEALLOCATE employee_cursor;

    -- Return sukses
    SELECT 1 AS Success, 'Generate Superior Subordinate completed successfully.' AS Message, NULL AS ErrorNote;
END TRY
BEGIN CATCH
    SELECT 
        0 AS Success, 
        'Unexpected error occurred.' AS Message, 
        ERROR_MESSAGE() AS ErrorNote;
END CATCH;
