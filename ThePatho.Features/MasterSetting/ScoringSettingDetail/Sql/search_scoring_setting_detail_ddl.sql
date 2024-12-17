SELECT 
    scoring_code AS ScoringCode,
    [value] AS Value,
    [character] AS CharacterValue,
    attachment AS Attachment,
    text_value AS TextValue

FROM [DB_TRIAL].[dbo].[TMScoringSetting]
WHERE
    (@ScoringCode IS NULL OR scoring_code LIKE '%' + @ScoringCode + '%') 

