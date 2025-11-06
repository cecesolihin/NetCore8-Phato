UPDATE TEPMEmployee 
SET IsDeleted = 1, 
	ModifiedBy = @User,
	ModifiedDate = GETDATE()
WHERE EmployeeID =@EmployeeID