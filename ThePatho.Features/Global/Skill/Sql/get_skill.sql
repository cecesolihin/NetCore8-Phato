DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
ORDER BY
    CASE WHEN @SortBy = 'SkillCode' THEN SkillCode END,
    CASE WHEN @SortBy = 'SkillName' THEN SkillName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;