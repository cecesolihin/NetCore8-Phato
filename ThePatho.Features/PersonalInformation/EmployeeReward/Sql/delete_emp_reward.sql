UPDATE dbo.TEPDEmployeeReward
SET
    IsDeleted = 1,
    ModifiedBy = @User,
    ModifiedDate = GETDATE()
WHERE EmRewardID = @EmRewardId;