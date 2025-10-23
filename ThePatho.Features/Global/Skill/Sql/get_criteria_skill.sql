SELECT 
    SkillCode,
    SkillName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMSkill
WHERE
    (@SkillCode IS NULL OR SkillCode LIKE '%' + @SkillCode + '%') AND
    (@SkillName IS NULL OR SkillName LIKE '%' + @SkillName + '%')