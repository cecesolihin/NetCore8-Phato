SELECT
    scoring_code AS ScoringCode,
    max_value AS MaxValue,
    min_value AS MinValue,
    numerical_type AS NumericalType,
    scoring_name AS ScoringName,
    scoring_type AS ScoringType,
    remark AS Remarks,
    inserted_by AS InsertedBy,
    CONVERT(VARCHAR(19), inserted_date, 120) AS InsertedDate,   -- Format: YYYY-MM-DD HH:MM:SS
    modified_by AS ModifiedBy,
    CONVERT(VARCHAR(19), modified_date, 120) AS ModifiedDate    -- Format: YYYY-MM-DD HH:MM:SS
FROM [DB_TRIAL].[dbo].[TMScoringSetting]
WHERE
    @ScoringCode IS NULL OR scoring_code = @ScoringCode
