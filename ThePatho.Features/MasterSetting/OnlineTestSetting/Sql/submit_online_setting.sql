IF (@Action = 'ADD')
BEGIN
    INSERT INTO [dbo].[TMOnlineTestSetting] (
        [online_test_code],
        [online_test_name],
        [test_question],
        [test_location],
        [status],
        [recruitment_req_no],
        [online_test_date_from],
        [online_test_date_to],
        [online_test_time_from],
        [online_test_time_to],
        [scoring_type],
        [email_template],
        [recruitment_step],
        [min_score],
        [quota],
        [inserted_by],
        [inserted_date]
    )
    VALUES (
        @OnlineTestCode,
        @OnlineTestName,
        @TestQuestion,
        @TestLocation,
        @Status,
        @RecruitmentReqNo,
        @OnlineTestDateFrom,
        @OnlineTestDateTo,
        @OnlineTestTimeFrom,
        @OnlineTestTimeTo,
        @ScoringType,
        @EmailTemplate,
        @RecruitmentStep,
        @MinScore,
        @Quota,
        @User,
        GETDATE()
    )
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE [dbo].[TMOnlineTestSetting]
    SET 
        [online_test_name] = @OnlineTestName,
        [test_question] = @TestQuestion,
        [test_location] = @TestLocation,
        [status] = @Status,
        [recruitment_req_no] = @RecruitmentReqNo,
        [online_test_date_from] = @OnlineTestDateFrom,
        [online_test_date_to] = @OnlineTestDateTo,
        [online_test_time_from] = @OnlineTestTimeFrom,
        [online_test_time_to] = @OnlineTestTimeTo,
        [scoring_type] = @ScoringType,
        [email_template] = @EmailTemplate,
        [recruitment_step] = @RecruitmentStep,
        [min_score] = @MinScore,
        [quota] = @Quota,
        [modified_by] = @User,
        [modified_date] = GETDATE()
    WHERE [online_test_code] = @OnlineTestCode
END
