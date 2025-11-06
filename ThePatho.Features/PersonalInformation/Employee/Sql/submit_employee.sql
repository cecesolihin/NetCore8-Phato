
DECLARE

	@CareerHistoryNo nvarchar(128)  ,
	@ChangeType nvarchar(max) ,
	@OrgStructureId int  ,
	@JobLevelCode nvarchar(50)  ,
	@GradeCode nvarchar(128)  ,
	@RankCode nvarchar(50)  ,
	@StartDate datetime 

BEGIN TRY
    ----------------------------------------------------
    -- 🔍 VALIDASI UMUM
    ----------------------------------------------------
    IF (@Action IS NULL OR LTRIM(RTRIM(@Action)) = '')
    BEGIN
        SELECT 0 AS Success, 'Action is required (ADD or EDIT).' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END

    IF (@CompanyCode IS NULL OR LTRIM(RTRIM(@CompanyCode)) = '')
    BEGIN
        SELECT 0 AS Success, 'CompanyCode is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	ELSE
	BEGIN
		 IF NOT EXISTS (SELECT 1 FROM TOGMCompanyProfile WHERE CompanyCode = @CompanyCode)
		 BEGIN
			SELECT 0 AS Success, 'CompanyCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END

	IF (@EmployeeNo IS NULL OR LTRIM(RTRIM(@EmployeeNo)) = '')
    BEGIN
        SELECT 0 AS Success, 'EmployeeNo is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	ELSE
	BEGIN
		 IF EXISTS (SELECT 1 FROM TEPMEmployee WHERE EmployeeNo = @EmployeeNo)
		 BEGIN
			SELECT 0 AS Success, 'EmployeeNo is AlReady Exists.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END

    IF (@Firstname IS NULL OR LTRIM(RTRIM(@Firstname)) = '')
    BEGIN
        SELECT 0 AS Success, 'Firstname is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END

	--Gender
	IF (@Gender IS NULL OR LTRIM(RTRIM(@Gender)) = '')
    BEGIN
        SELECT 0 AS Success, 'Gender is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END

	--PositionCode
    IF (@PositionCode IS NULL OR LTRIM(RTRIM(@PositionCode)) = '')
    BEGIN
        SELECT 0 AS Success, 'PositionCode is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	BEGIN
		 IF NOT EXISTS (SELECT 1 FROM TOGMPosition WHERE PositionCode = @PositionCode)
		 BEGIN
			SELECT 0 AS Success, 'PositionCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END

	--JobClassCode
	IF (@JobClassCode IS NULL OR LTRIM(RTRIM(@JobClassCode)) = '')
    BEGIN
        SELECT 0 AS Success, 'JobClassCode is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	BEGIN
		 IF NOT EXISTS (SELECT 1 FROM TOGMJobClass WHERE JobClassCode = @JobClassCode)
		 BEGIN
			SELECT 0 AS Success, 'JobClassCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END
	--JoinDate
    IF (@JoinDate IS NULL)
    BEGIN
        SELECT 0 AS Success, 'JoinDate is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	--BirthDate
	IF (@BirthDate IS NULL)
    BEGIN
        SELECT 0 AS Success, 'BirthDate is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END

	--EmploymentTypeCode
	IF (@EmploymentTypeCode IS NULL OR LTRIM(RTRIM(@EmploymentTypeCode)) = '')
    BEGIN
        SELECT 0 AS Success, 'EmploymentTypeCode is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	BEGIN
		 IF NOT EXISTS (SELECT 1 FROM TOGMEmploymentType WHERE EmploymentTypeCode = @EmploymentTypeCode)
		 BEGIN
			SELECT 0 AS Success, 'EmploymentTypeCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END
	--CostCenterCode
	IF (@CostCenterCode IS NULL OR LTRIM(RTRIM(@CostCenterCode)) = '')
    BEGIN
        SELECT 0 AS Success, 'CostCenterCode is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	BEGIN
		 IF NOT EXISTS (SELECT 1 FROM TOGMCostCenter WHERE CostCenterCode = @CostCenterCode)
		 BEGIN
			SELECT 0 AS Success, 'CostCenterCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END
	--TaxStatusCode
	IF (@TaxStatusCode IS NULL OR LTRIM(RTRIM(@TaxStatusCode)) = '')
    BEGIN
        SELECT 0 AS Success, 'TaxStatusCode is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	BEGIN
		 IF NOT EXISTS (SELECT 1 FROM TGEMTaxStatus WHERE TaxStatusCode = @TaxStatusCode)
		 BEGIN
			SELECT 0 AS Success, 'TaxStatusCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END
	--WorkLocationCode
	IF (@WorkLocationCode IS NOT NULL)
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM TOGMWorkLocation WHERE WorkLocationCode = @WorkLocationCode)
		 BEGIN
			SELECT 0 AS Success, 'WorkLocationCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END

	--NationalityID
	IF (@NationalityID IS NOT NULL)
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM TGEMNationality WHERE NationalityID = @NationalityID)
		 BEGIN
			SELECT 0 AS Success, 'Nationality is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END
	--ReligionID
	IF (@ReligionID IS NOT NULL)
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM TGEMReligion WHERE ReligionID = @ReligionID)
		 BEGIN
			SELECT 0 AS Success, 'Religion is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END

	--BloodType
	IF (@BloodType IS NOT NULL)
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM TGEMBloodType WHERE BloodTypeCode = @BloodType)
		 BEGIN
			SELECT 0 AS Success, 'BloodType is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END

	--BuildingCode
	IF (@BuildingCode IS NOT NULL)
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM TGEMBuilding WHERE BuildingCode = @BuildingCode)
		 BEGIN
			SELECT 0 AS Success, 'BuildingCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END

	--RoomCode
	IF (@RoomCode IS NOT NULL)
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM TGEMRoom WHERE RoomCode = @RoomCode)
		 BEGIN
			SELECT 0 AS Success, 'RoomCode is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END

	--MaritalStatus
	IF (@MaritalStatus IS NULL OR LTRIM(RTRIM(@MaritalStatus)) = '')
    BEGIN
        SELECT 0 AS Success, 'MaritalStatus is required.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END
	BEGIN
		 IF NOT EXISTS (SELECT 1 FROM TGEMMaritalStatus WHERE MaritalStatusCode = @MaritalStatus)
		 BEGIN
			SELECT 0 AS Success, 'MaritalStatus is not found.' AS Message, 'Validation Error' AS ErrorNote;
			RETURN
		 END
	END


    IF (@Action = 'ADD' AND (@EmployeeNo IS NULL OR LTRIM(RTRIM(@EmployeeNo)) = ''))
    BEGIN
        SELECT 0 AS Success, 'EmployeeNo is required for ADD.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END

    IF (@Action = 'EDIT' AND @EmployeeId IS NULL)
    BEGIN
        SELECT 0 AS Success, 'EmployeeId is required for EDIT.' AS Message, 'Validation Error' AS ErrorNote;
        RETURN;
    END

	
    ----------------------------------------------------
    -- 🔁 AKSI ADD
    ----------------------------------------------------
    IF @Action = 'ADD'
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION;

            IF EXISTS (SELECT 1 FROM [dbo].[TEPMEmployee] WHERE EmployeeNo = @EmployeeNo AND IsDeleted = 0)
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Success, 'EmployeeNo already exists.' AS Message, 'Duplicate Error' AS ErrorNote;
                RETURN;
            END

			--SET hard code
			SET @TaxType ='Local'
			SET @IsDeleted = 0
			SET @TaxLocationID =1
			SET @IsEligibleRehire = 0
			SET @SeverancePaid = 0
			SET @StatusIDCard = 0
			SET @IsDonate =0

            INSERT INTO [dbo].[TEPMEmployee]
            (
                EmployeeNo, CompanyCode, Firstname, MiddleName, LastName, Fullname,
                PositionCode, Gender, BirthPlace, BirthDate, JoinDate, TerminateDate,
                PermanentDate, PensionDate, JobClassCode, EmploymentTypeCode, CostCenterCode,
                TaxType, TaxStatusCode, NPWP, AttendanceID, IsDeleted, WorkLocationCode,
                InsertedBy, InsertedDate, ModifiedBy, ModifiedDate, TaxLocationID, NeedReplacement,
                BPJSTKLocation, BPJSKesLocation, CapColorId, PickUpId, ContractEndDate,
                JabatanId, IsEligibleRehire, FaskesId
            )
            VALUES
            (
                @EmployeeNo, @CompanyCode, @Firstname, @MiddleName, @LastName, @Fullname,
                @PositionCode, @Gender, @BirthPlace, @BirthDate, @JoinDate, @TerminateDate,
                @PermanentDate, @PensionDate, @JobClassCode, @EmploymentTypeCode, @CostCenterCode,
                @TaxType, @TaxStatusCode, @Npwp, @AttendanceId, 0, @WorkLocationCode,
                @User, GETDATE(), NULL, NULL, @TaxLocationId, @NeedReplacement,
                @BpjstkLocation, @BpjskesLocation, @CapColorId, @PickUpId, @ContractEndDate,
                @JabatanId, @IsEligibleRehire, @FaskesId
            );

            DECLARE @NewEmployeeID INT = SCOPE_IDENTITY();

            ----------------------------------------------------
            -- INSERT PersonalData
            ----------------------------------------------------
            INSERT INTO [dbo].[TEPDEmployeePersonalData]
            (
                EmployeeID, CompanyCode, NationalityID, ReligionID, MaritalStatus, MarriedDate,
                BPJSTK, BPJSKES, NickName, Phone, MobilePhone, Email, BloodType, Height, [Weight],
                OfficePhone, OfficeEmail, BuildingCode, RoomCode, ComputerName, StaticIPAddress,
                Glasses, LeftEye, RightEye, Hat, Helmet, Clothes, Jacket, Pants, Shoes, Boots,
                IsDeleted, PhotoPath, InsertedBy, InsertedDate, ModifiedBy, ModifiedDate,
                SeverancePaid, SeverancePaidDate, RFID, Recruiter, HireOrigin, PayGroup,
                StatusIDCard, IsDonate
            )
            VALUES
            (
                @NewEmployeeID, @CompanyCode, @NationalityID, @ReligionID, @MaritalStatus, @MarriedDate,
                @BPJSTK, @BPJSKES, @NickName, @Phone, @MobilePhone, @Email, @BloodType, @Height, @Weight,
                @OfficePhone, @OfficeEmail, @BuildingCode, @RoomCode, @ComputerName, @StaticIPAddress,
                @Glasses, @LeftEye, @RightEye, @Hat, @Helmet, @Clothes, @Jacket, @Pants, @Shoes, @Boots,
                0, @PhotoPath, @User, GETDATE(), NULL, NULL,
                0, NULL, @RFID, @Recruiter, @HireOrigin, @PayGroup,
                0, 0
            );

            ----------------------------------------------------
            -- INSERT Career History
            ----------------------------------------------------
			SELECT TOP 1 
				@OrgStructureId = OrgStructureID , 
				@JobLevelCode = JobLevelCode
			FROM TOGMPosition WHERE PositionCode = @PositionCode

			SELECT TOP 1 
				@GradeCode = GradeCode , 
				@RankCode = RankCode
			FROM TOGMJobClass WHERE JobClassCode = @JobClassCode

            INSERT INTO [dbo].[TEPDEmployeeCareerHistory]
            (
                CareerHistoryNo, EmployeeID, EmployeeNo, CompanyCode, EmploymentTypeCode,
                ChangeType, PositionCode, OrgStructureId, JobLevelCode, JobClassCode,
                GradeCode, RankCode, CostCenterCode, StartDate, Remark,
                IsDeleted, WorkLocationCode, InsertedBy, InsertedDate, JabatanId, IsEligibleRehire
            )
            VALUES
            (
                CONCAT('CH-', @EmployeeNo, '-', CONVERT(VARCHAR(8), GETDATE(), 112)),
                @NewEmployeeID, @EmployeeNo, @CompanyCode, @EmploymentTypeCode,
                'JOIN', @PositionCode, @OrgStructureId, @JobLevelCode, @JobClassCode,
                @GradeCode, @RankCode, @CostCenterCode, @JoinDate, 'JOINING EMPLOYEE',
                0, @WorkLocationCode, @User, GETDATE(), @JabatanId, @IsEligibleRehire
            );

            COMMIT TRANSACTION;
            SELECT 1 AS Success, 'Employee successfully added.' AS Message, NULL AS ErrorNote;
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            SELECT 0 AS Success, 'Failed to add employee.' AS Message, ERROR_MESSAGE() AS ErrorNote;
        END CATCH;
    END

    ----------------------------------------------------
    -- 🔁 AKSI EDIT
    ----------------------------------------------------
    ELSE IF @Action = 'EDIT'
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION;

            IF NOT EXISTS (SELECT 1 FROM [dbo].[TEPMEmployee] WHERE EmployeeID = @EmployeeId AND IsDeleted = 0)
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Success, 'Employee not found.' AS Message, 'Invalid EmployeeId' AS ErrorNote;
                RETURN;
            END

            ----------------------------------------------------
            -- UPDATE Employee
            ----------------------------------------------------
            UPDATE [dbo].[TEPMEmployee]
            SET
                Firstname = @Firstname,
                MiddleName = @MiddleName,
                LastName = @LastName,
                Fullname = @Fullname,
                PositionCode = @PositionCode,
                Gender = @Gender,
                BirthPlace = @BirthPlace,
                BirthDate = @BirthDate,
                JoinDate = @JoinDate,
                TerminateDate = @TerminateDate,
                PermanentDate = @PermanentDate,
                PensionDate = @PensionDate,
                JobClassCode = @JobClassCode,
                EmploymentTypeCode = @EmploymentTypeCode,
                CostCenterCode = @CostCenterCode,
                TaxType = @TaxType,
                TaxStatusCode = @TaxStatusCode,
                NPWP = @Npwp,
                WorkLocationCode = @WorkLocationCode,
                ModifiedBy = @User,
                ModifiedDate = GETDATE()
            WHERE EmployeeID = @EmployeeId;

            ----------------------------------------------------
            -- UPDATE Personal Data
            ----------------------------------------------------
            UPDATE [dbo].[TEPDEmployeePersonalData]
            SET
                NationalityID = @NationalityID,
                ReligionID = @ReligionID,
                MaritalStatus = @MaritalStatus,
                MarriedDate = @MarriedDate,
                BPJSTK = @BPJSTK,
                BPJSKES = @BPJSKES,
                NickName = @NickName,
                Phone = @Phone,
                MobilePhone = @MobilePhone,
                Email = @Email,
                BloodType = @BloodType,
                Height = @Height,
                Weight = @Weight,
                OfficePhone = @OfficePhone,
                OfficeEmail = @OfficeEmail,
                BuildingCode = @BuildingCode,
                RoomCode = @RoomCode,
                ComputerName = @ComputerName,
                StaticIPAddress = @StaticIPAddress,
                Glasses = @Glasses,
                LeftEye = @LeftEye,
                RightEye = @RightEye,
                Hat = @Hat,
                Helmet = @Helmet,
                Clothes = @Clothes,
                Jacket = @Jacket,
                Pants = @Pants,
                Shoes = @Shoes,
                Boots = @Boots,
                PhotoPath = @PhotoPath,
                RFID = @RFID,
                Recruiter = @Recruiter,
                HireOrigin = @HireOrigin,
                PayGroup = @PayGroup,
                ModifiedBy = @User,
                ModifiedDate = GETDATE()
            WHERE EmployeeID = @EmployeeId;

            COMMIT TRANSACTION;
            SELECT 1 AS Success, 'Employee successfully updated.' AS Message, NULL AS ErrorNote;
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            SELECT 0 AS Success, 'Failed to update employee.' AS Message, ERROR_MESSAGE() AS ErrorNote;
        END CATCH;
    END
    ----------------------------------------------------
    ELSE
    BEGIN
        SELECT 0 AS Success, 'Invalid Action (must be ADD or EDIT).' AS Message, 'Validation Error' AS ErrorNote;
    END
END TRY
BEGIN CATCH
    SELECT 0 AS Success, 'Unexpected error occurred.' AS Message, ERROR_MESSAGE() AS ErrorNote;
END CATCH;
