SELECT 
    EmployeeID,
    SkillCode,
    ProfiencyCode,
    Description,
     CONVERT(VARCHAR, TakenDate, 106) AS TakenDate,  -- dd MMM yyyy TakenDate,
     CONVERT(VARCHAR, ExpiredDate, 106) AS ExpiredDate,  -- dd MMM yyyy ExpiredDate,
    Remarks,
    IsDeleted,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate   -- dd MMM yyyy
FROM 
    dbo.TEPDEmployeeSkill
WHERE EmployeeID = @EmployeeId AND
      SkillCode = @SkillCode
