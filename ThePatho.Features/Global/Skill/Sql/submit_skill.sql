IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMSkill
    (
        SkillCode,
        SkillName,
        IsDeletd,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @SkillCode,
        @SkillName,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMSkill
    SET
        SkillCode = @SkillCode,
        SkillName   = @SkillName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        SkillCode = @SkillCode;
END	