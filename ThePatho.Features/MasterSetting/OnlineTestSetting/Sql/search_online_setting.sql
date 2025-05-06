DECLARE @Offset INT = @PageNumber * @PageSize;

SELECT 
    online_test_code AS OnlineTestCode,
    online_test_name AS OnlineTestName,
    test_question AS TestQuestion,
    test_location AS TestLocation,
    status AS Status,
    recruitment_req_no AS RecruitmentRequestNumber,
    CONVERT(VARCHAR(10), online_test_date_from, 120) AS OnlineTestDateFrom, -- Format: YYYY-MM-DD
    CONVERT(VARCHAR(10), online_test_date_to, 120) AS OnlineTestDateTo,     -- Format: YYYY-MM-DD
    CONVERT(VARCHAR(8), online_test_time_from, 108) AS OnlineTestTimeFrom,  -- Format: HH:MM:SS
    CONVERT(VARCHAR(8), online_test_time_to, 108) AS OnlineTestTimeTo,   
    scoring_type AS ScoringType,
    email_template AS EmailTemplate,
    recruitment_step AS RecruitmentStep,
    min_score AS MinimumScore,
    quota AS Quota,
    inserted_by AS InsertedBy,
    CONVERT(VARCHAR, inserted_date, 120) AS InsertedDate,
    modified_by AS ModifiedBy,
    CONVERT(VARCHAR, modified_date, 120) AS ModifiedDate
FROM dbo.TMOnlineTestSetting
WHERE
    (@OnlineTestCode IS NULL OR online_test_code LIKE '%' + @OnlineTestCode + '%') AND
    (@OnlineTestName IS NULL OR online_test_name LIKE '%' + @OnlineTestName + '%') AND
    (@TestQuestion IS NULL OR test_question LIKE '%' + @TestQuestion + '%') 
    ORDER BY
    CASE WHEN @SortBy = 'OnlineTestCode' THEN online_test_code END,
    CASE WHEN @SortBy = 'OnlineTestName' THEN online_test_name END,
    CASE WHEN @SortBy = 'TestQuestion' THEN test_question END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, inserted_date, 120) END
    , CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
      END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;