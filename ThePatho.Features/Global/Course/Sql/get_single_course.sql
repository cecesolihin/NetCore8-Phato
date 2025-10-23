SELECT 
    CourseCode,
    CourseName,
    TrainingFieldCode,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMCourse
WHERE
    CourseCode = @CourseCode