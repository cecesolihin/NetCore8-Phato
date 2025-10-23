IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMRewardType
    (
        RewardTypeCode,
        RewardTypeName,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @RewardTypeCode,
        @RewardTypeName,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMRewardType
    SET
        RewardTypeCode = @RewardTypeCode,
        RewardTypeName   = @RewardTypeName,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        RewardTypeCode = @RewardTypeCode;
END	