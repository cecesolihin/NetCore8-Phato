DECLARE @Offset INT = @PageNumber * @PageSize;
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
    (@ScoringCode IS NULL OR scoring_code LIKE '%' + @ScoringCode + '%') 
ORDER BY
    CASE WHEN @SortBy = 'ScoringCode' THEN scoring_code END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, inserted_date, 120) END
    , CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
      END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
