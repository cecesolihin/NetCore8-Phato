UPDATE
    dbo.TGEMCourse
SET IsDeleted = 1
WHERE
    CourseCode = @CourseCode