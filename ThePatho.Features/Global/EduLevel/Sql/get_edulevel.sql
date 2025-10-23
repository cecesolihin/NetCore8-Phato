DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    EduLevelCode,
    EduLevelName,
    Sort,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMEduLevel
WHERE
    (@EduLevelCode IS NULL OR EduLevelCode LIKE '%' + @EduLevelCode + '%') AND
    (@EduLevelName IS NULL OR EduLevelName LIKE '%' + @EduLevelName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'EduLevelCode' THEN EduLevelCode END,
    CASE WHEN @SortBy = 'EduLevelName' THEN EduLevelName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
