DECLARE @Offset INT = @PageNumber * @PageSize;
SELECT
    scoring_code AS ScoringCode,
    scoring_name AS ScoringName
    
FROM [DB_TRIAL].[dbo].[TMScoringSetting]
WHERE
    @ScoringCode IS NULL OR scoring_code LIKE '%' + @ScoringCode + '%'

