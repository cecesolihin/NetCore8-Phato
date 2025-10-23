UPDATE
    dbo.TGEMSkillProfiency
SET IsDeleted = 1
WHERE
    ProfiencyCode = @ProfiencyCode