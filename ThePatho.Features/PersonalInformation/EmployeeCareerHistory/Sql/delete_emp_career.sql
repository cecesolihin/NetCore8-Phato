
    UPDATE TEPDEmployeeCareerHistory
    SET IsDeleted = 1,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE CareerHistoryNo = @CareerHistoryNo AND EmployeeID = @EmployeeID
