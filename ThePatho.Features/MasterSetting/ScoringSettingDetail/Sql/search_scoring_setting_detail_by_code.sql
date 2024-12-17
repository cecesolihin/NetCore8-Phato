SELECT 
    scoring_code AS ScoringCode,
    [value] AS Value,
    [character] AS CharacterValue,
    attachment AS Attachment,
    text_value AS TextValue,
    inserted_by AS InsertedBy,
    CONVERT(VARCHAR(19), inserted_date, 120) AS InsertedDate,
    modified_by AS ModifiedBy,
    CONVERT(VARCHAR(19), modified_date, 120) AS ModifiedDate 
FROM [DB_TRIAL].[dbo].[TMScoringSetting]
WHERE
    scoring_code = @ScoringCode 

