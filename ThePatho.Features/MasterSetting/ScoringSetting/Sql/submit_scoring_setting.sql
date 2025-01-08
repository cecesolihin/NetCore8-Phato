IF (@Action = 'ADD')
BEGIN
    INSERT INTO [dbo].[TMScoringSetting] (
        [scoring_code],
        [max_value],
        [min_value],
        [numerical_type],
        [scoring_name],
        [scoring_type],
        [remark],
        [inserted_by],
        [inserted_date]
    )
    VALUES (
        NEWID(), -- Generate a unique identifier for scoring_code
        @MaxValue,
        @MinValue,
        @NumericalType,
        @ScoringName,
        @ScoringType,
        @Remark,
        @User,
        GETDATE()
    )
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE [dbo].[TMScoringSetting]
    SET 
        [max_value] = @MaxValue,
        [min_value] = @MinValue,
        [numerical_type] = @NumericalType,
        [scoring_name] = @ScoringName,
        [scoring_type] = @ScoringType,
        [remark] = @Remark,
        [modified_by] = @User,
        [modified_date] = GETDATE()
    WHERE [scoring_code] = @ScoringCode
END
