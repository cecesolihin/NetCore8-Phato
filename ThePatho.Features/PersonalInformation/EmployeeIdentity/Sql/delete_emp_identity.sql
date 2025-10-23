UPDATE dbo.TEPDEmployeeIdentity
    SET 
        IsDeleted = 1,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeID = @EmployeeId AND IdentityCode = @IdentityCode;