UPDATE dbo.TEPDEmployeeMedical
    SET 
        IsDeleted = 1,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeID = @EmployeeId AND DiseaseCategoryCode = @DiseaseCategoryCode;