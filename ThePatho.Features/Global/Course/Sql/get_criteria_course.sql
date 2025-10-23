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