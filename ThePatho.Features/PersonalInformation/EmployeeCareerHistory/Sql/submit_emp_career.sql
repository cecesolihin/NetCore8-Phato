BEGIN TRY

    -- ==============================
    -- VALIDATION SECTION
    -- ==============================
    IF @EmployeeId IS NULL OR @CompanyCode IS NULL OR @PositionCode IS NULL 
       OR @JobClassCode IS NULL OR @EmploymentTypeCode IS NULL 
       OR @CostCenterCode IS NULL OR @JobLevelCode IS NULL
    BEGIN
        SELECT 0 AS Success, 'Validation failed.' AS Message,
               'Required fields missing: EmployeeId, CompanyCode, PositionCode, JobClassCode, EmploymentTypeCode, CostCenterCode, JobLevelCode.' AS ErrorNote;
        RETURN;
    END;

    -- ==============================
    -- ACTION: ADD
    -- ==============================
    IF @Action = 'ADD'
    BEGIN
        IF EXISTS(SELECT 1 FROM TEPDEmployeeCareerHistory WHERE CareerHistoryNo = @CareerHistoryNo)
        BEGIN
            SELECT 0 AS Success, 'Add failed.' AS Message, 'CareerHistoryNo already exists.' AS ErrorNote;
            RETURN;
        END;

        INSERT INTO [dbo].[TEPDEmployeeCareerHistory] (
            [CareerHistoryNo], [EmployeeID], [EmployeeNo], [CompanyCode],
            [EmploymentTypeCode], [ChangeType], [PositionCode], [OrgStructureId],
            [JobLevelCode], [JobClassCode], [GradeCode], [RankCode],
            [CostCenterCode], [StartDate], [EndDate], [Remark],
            [IsDeleted], [WorkLocationCode], [ResignTypeCode], [TerminationTypeCode],
            [InsertedBy], [InsertedDate], [PensionTypeCode], [AssignmentLocation],
            [EffectiveDateTo], [TaxLocationID], [IsIncludeSalary], [EmpSalCompId],
            [MutationTypeCode], [UsePayrollData], [UseOldJoinDate], [JoinDate],
            [OldEmployeeId], [Path], [JabatanId], [IsEligibleRehire]
        )
        VALUES (
            @CareerHistoryNo, @EmployeeId, @EmployeeNo, @CompanyCode,
            @EmploymentTypeCode, @ChangeType, @PositionCode, @OrgStructureId,
            @JobLevelCode, @JobClassCode, @GradeCode, @RankCode,
            @CostCenterCode, @StartDate, @EndDate, @Remark,
            @IsDeleted, @WorkLocationCode, @ResignTypeCode, @TerminationTypeCode,
            @User, GETDATE(), @PensionTypeCode, @AssignmentLocation,
            @EffectiveDateTo, @TaxLocationId, @IsIncludeSalary, @EmpSalCompId,
            @MutationTypeCode, @UsePayrollData, @UseOldJoinDate, @JoinDate,
            @OldEmployeeId, @Path, @JabatanId, @IsEligibleRehire
        );

        SELECT 1 AS Success, 'Add successful.' AS Message, NULL AS ErrorNote;
    END;


    -- ==============================
    -- ACTION: EDIT
    -- ==============================
    IF @Action = 'EDIT'
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM TEPDEmployeeCareerHistory WHERE CareerHistoryNo = @CareerHistoryNo)
        BEGIN
            SELECT 0 AS Success, 'Edit failed.' AS Message, 'CareerHistory record not found.' AS ErrorNote;
            RETURN;
        END;

        UPDATE [dbo].[TEPDEmployeeCareerHistory]
        SET
            EmployeeID = @EmployeeId,
            EmployeeNo = @EmployeeNo,
            CompanyCode = @CompanyCode,
            EmploymentTypeCode = @EmploymentTypeCode,
            ChangeType = @ChangeType,
            PositionCode = @PositionCode,
            OrgStructureId = @OrgStructureId,
            JobLevelCode = @JobLevelCode,
            JobClassCode = @JobClassCode,
            GradeCode = @GradeCode,
            RankCode = @RankCode,
            CostCenterCode = @CostCenterCode,
            StartDate = @StartDate,
            EndDate = @EndDate,
            Remark = @Remark,
            IsDeleted = @IsDeleted,
            WorkLocationCode = @WorkLocationCode,
            ResignTypeCode = @ResignTypeCode,
            TerminationTypeCode = @TerminationTypeCode,
            ModifiedBy = @User,
            ModifiedDate = GETDATE(),
            PensionTypeCode = @PensionTypeCode,
            AssignmentLocation = @AssignmentLocation,
            EffectiveDateTo = @EffectiveDateTo,
            TaxLocationID = @TaxLocationId,
            IsIncludeSalary = @IsIncludeSalary,
            EmpSalCompId = @EmpSalCompId,
            MutationTypeCode = @MutationTypeCode,
            UsePayrollData = @UsePayrollData,
            UseOldJoinDate = @UseOldJoinDate,
            JoinDate = @JoinDate,
            OldEmployeeId = @OldEmployeeId,
            Path = @Path,
            JabatanId = @JabatanId,
            IsEligibleRehire = @IsEligibleRehire
        WHERE CareerHistoryNo = @CareerHistoryNo;

        SELECT 1 AS Success, 'Edit successful.' AS Message, NULL AS ErrorNote;
    END;


    -- ==============================
    -- UPDATE EMPLOYEE IF StartDate >= TODAY
    -- ==============================
    IF @StartDate >= CAST(GETDATE() AS DATE)
    BEGIN
        UPDATE [dbo].[TEPMEmployee]
        SET 
            PositionCode       = @PositionCode,
            TerminateDate      = @EndDate,
            PermanentDate      = CASE WHEN @EmploymentTypeCode = 'PERM' THEN @StartDate ELSE PermanentDate END,
            JobClassCode       = @JobClassCode,
            EmploymentTypeCode = @EmploymentTypeCode,
            CostCenterCode     = @CostCenterCode,
            TaxStatusCode      = ISNULL(@TaxStatusCode, TaxStatusCode),
            WorkLocationCode   = @WorkLocationCode,
            ContractEndDate    = @EndDate,
            ModifiedBy         = @User,
            ModifiedDate       = GETDATE()
        WHERE EmployeeID = @EmployeeId;
    END;

END TRY

BEGIN CATCH
    SELECT 0 AS Success, 'Unexpected error occurred.' AS Message, ERROR_MESSAGE() AS ErrorNote;
END CATCH;
