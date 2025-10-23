UPDATE dbo.TEPDEmployeeSkill
SET
    IsDeleted = 1,
    ModifiedBy = @User,
    ModifiedDate = GETDATE()
WHERE EmployeeID = @EmployeeId
    AND SkillCode = @SkillCode;