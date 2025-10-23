IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMCourse
    (
        CourseCode,
        CourseName,
        TrainingFieldCode,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @CourseCode,
        @CourseName,
        @TrainingFieldCode,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMCourse
    SET
        CourseCode = @CourseCode,
        CourseName   = @CourseName,
        TrainingFieldCode = @TrainingFieldCode,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        CourseCode = @CourseCode;
END	