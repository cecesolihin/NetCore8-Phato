DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
WHERE
    (@EmployeeId = 0 OR EmployeeID = @EmployeeId) AND
    (   
        @Skill IS NULL OR @Skill = '' 
        OR SkillCode LIKE '%' + @SkillCode + '%'
        OR ProfiencyCode LIKE '%' + @ProfiencyCode + '%'
     ) AND
    IsDeleted = 0
ORDER BY
    CASE WHEN @SortBy = 'SkillCode' THEN SkillCode END,
    CASE WHEN @SortBy = 'ProfiencyCode' THEN ProfiencyCode END,
    CASE WHEN @SortBy = 'TakenDate' THEN TakenDate END,
    CASE WHEN @SortBy = 'ExpiredDate' THEN ExpiredDate END,
    CASE WHEN @SortBy = 'InsertedDate' THEN InsertedDate END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN ModifiedDate END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
