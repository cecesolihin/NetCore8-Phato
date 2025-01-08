IF (@Action = 'ADD')
BEGIN
    INSERT INTO [dbo].[TMScoringSettingDetail] (
        [scoring_code],
        [value],
        [character],
        [attachment],
        [text_value],
        [inserted_by],
        [inserted_date]
    )
    VALUES (
        @ScoringCode,
        @Value,
        @Character,
        @Attachment,
        @TextValue,
        @User,
        GETDATE()
    )
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE [dbo].[TMScoringSettingDetail]
    SET 
        [value] = @Value,
        [attachment] = @Attachment,
        [text_value] = @TextValue,
        [modified_by] = @User,
        [modified_date] = GETDATE()
    WHERE [scoring_code] = @ScoringCode AND [character] = @Character
END
