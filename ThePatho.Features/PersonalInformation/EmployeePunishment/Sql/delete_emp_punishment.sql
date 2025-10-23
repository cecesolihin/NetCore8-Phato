UPDATE dbo.TEPDEmployeePunishment
SET
    IsDeleted = 1,
    ModifiedBy = @User,
    ModifiedDate = GETDATE()
WHERE EmPunishmentID = @EmPunishmentId;