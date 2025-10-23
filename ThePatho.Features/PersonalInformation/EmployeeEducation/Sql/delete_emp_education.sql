UPDATE TEPDEmployeeEducation
SET 
    IsDeleted = 1,
    ModifiedBy = @User,
    ModifiedDate = GETDATE()
WHERE EmployeeEducationID = @EmployeeEducationId;
