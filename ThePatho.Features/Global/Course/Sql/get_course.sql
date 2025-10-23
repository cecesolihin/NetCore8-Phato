SELECT 
    CourseCode,
    CourseName,
    TrainingFieldCode,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMCourse
WHERE
    (@CourseCode IS NULL OR CourseCode LIKE '%' + @CourseCode + '%') AND
    (@CourseName IS NULL OR CourseName LIKE '%' + @CourseName + '%') AND
    (@TrainingFieldCode IS NULL OR TrainingFieldCode LIKE '%' + @TrainingFieldCode + '%') 
ORDER BY
    CASE WHEN @SortBy = 'CourseCode' THEN CourseCode END,
    CASE WHEN @SortBy = 'CourseName' THEN CourseName END,
    CASE WHEN @SortBy = 'TrainingFieldCode' THEN TrainingFieldCode END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;