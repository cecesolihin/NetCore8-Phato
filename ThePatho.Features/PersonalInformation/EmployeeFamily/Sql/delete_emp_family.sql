UPDATE TEPDEmployeeFamily
    SET 
        IsDeleted = 1,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeFamilyID = @EmployeeFamilyId;