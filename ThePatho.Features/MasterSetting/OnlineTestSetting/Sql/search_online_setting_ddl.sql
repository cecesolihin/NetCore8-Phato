
SELECT 
    online_test_code AS OnlineTestCode,
    online_test_name AS OnlineTestName

FROM dbo.TMOnlineTestSetting
WHERE
    @RecruitmentRequestNo IS NULL OR recruitment_req_no LIKE '%' + @RecruitmentRequestNo + '%'
