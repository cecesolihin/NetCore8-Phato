IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TEPDEmployeeReward
    (
        LetterNo,
        EmployeeID,
        LetterDate,
        RewardTypeCode,
        Remarks,
        CurrencyCode,
        Amount,
        Attachment,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @LetterNo,
        @EmployeeId,
        @LetterDate,
        @RewardTypeCode,
        @Remarks,
        @CurrencyCode,
        @Amount,
        @Attachment,
        0, -- default active
        @User,
        GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TEPDEmployeeReward
    SET
        LetterNo = @LetterNo,
        EmployeeID = @EmployeeId,
        LetterDate = @LetterDate,
        RewardTypeCode = @RewardTypeCode,
        Remarks = @Remarks,
        CurrencyCode = @CurrencyCode,
        Amount = @Amount,
        Attachment = @Attachment,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmRewardID = @EmRewardId;
END

