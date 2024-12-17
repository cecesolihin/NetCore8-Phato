SELECT 
    questionnaire_code AS QuestionnaireCode,
    questionnaire_name AS QuestionnaireName,
    questionnaire_type AS QuestionnaireType,
    remarks AS Remarks,
    active AS IsActive,
    inserted_by AS InsertedBy,
    CONVERT(VARCHAR(19), inserted_date, 120) AS InsertedDate,
    modified_by AS ModifiedBy,
    answer_method AS AnswerMethod,
    random_question AS IsRandomQuestion,
    CONVERT(VARCHAR(19), modified_date, 120) AS ModifiedDate
FROM [dbo].[TMQuestionSetting]
WHERE
    questionnaire_code = @QuestionCode 