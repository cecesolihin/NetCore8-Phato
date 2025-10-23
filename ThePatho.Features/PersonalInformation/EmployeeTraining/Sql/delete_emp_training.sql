UPDATE dbo.TEPDEmployeeTraining
SET
    IsDeleted = 1,
    ModifiedBy = @User,
    ModifiedDate = GETDATE()
WHERE EmpTrainingId = @EmpTrainingId;