DECLARE @Offset INT = @PageNumber * @PageSize;
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
    (@ScoringCode IS NULL OR scoring_code LIKE '%' + @ScoringCode + '%') AND
    (@ScoringName IS NULL OR scoring_name LIKE '%' + @ScoringName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'ScoringCode' THEN scoring_code END,
    CASE WHEN @SortBy = 'ScoringName' THEN scoring_name END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, inserted_date, 120) END
    , CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
      END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
