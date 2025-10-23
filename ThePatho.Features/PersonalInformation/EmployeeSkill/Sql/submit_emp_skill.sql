IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TEPDEmployeeSkill
    (
        EmployeeID,
        SkillCode,
        ProfiencyCode,
        Description,
        TakenDate,
        ExpiredDate,
        Remarks,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @EmployeeId,
        @SkillCode,
        @ProfiencyCode,
        @Description,
        @TakenDate,
        @ExpiredDate,
        @Remarks,
        0, -- default active
        @User,
        GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TEPDEmployeeSkill
    SET
        ProfiencyCode = @ProfiencyCode,
        Description = @Description,
        TakenDate = @TakenDate,
        ExpiredDate = @ExpiredDate,
        Remarks = @Remarks,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeID = @EmployeeId
      AND SkillCode = @SkillCode;
END
