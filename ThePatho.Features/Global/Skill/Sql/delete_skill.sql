UPDATE
    dbo.TGEMSkill
SET IsDeleted = 1
WHERE
    SkillCode = @SkillCode