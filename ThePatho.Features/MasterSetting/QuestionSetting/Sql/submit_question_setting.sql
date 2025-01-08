IF (@Action = 'ADD')
BEGIN
    INSERT INTO [dbo].[TMQuestionSetting] (
        [questionnaire_code],
        [questionnaire_name],
        [questionnaire_type],
        [remarks],
        [active],
        [answer_method],
        [random_question],
        [inserted_by],
        [inserted_date]
    )
    VALUES (
        @QuestionnaireCode,
        @QuestionnaireName,
        @QuestionnaireType,
        @Remarks,
        @Active,
        @AnswerMethod,
        @RandomQuestion,
        @User,
        GETDATE()
    )
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE [dbo].[TMQuestionSetting]
    SET 
        [questionnaire_name] = @QuestionnaireName,
        [questionnaire_type] = @QuestionnaireType,
        [remarks] = @Remarks,
        [active] = @Active,
        [answer_method] = @AnswerMethod,
        [random_question] = @RandomQuestion,
        [modified_by] = @User,
        [modified_date] = GETDATE()
    WHERE [questionnaire_code] = @QuestionnaireCode
END
