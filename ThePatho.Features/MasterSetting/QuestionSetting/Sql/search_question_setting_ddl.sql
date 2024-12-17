SELECT 
    questionnaire_code AS QuestionnaireCode,
    questionnaire_name AS QuestionnaireName
FROM [dbo].[TMQuestionSetting]
WHERE
    @QuestionCode IS NULL OR questionnaire_code LIKE '%' + @QuestionCode + '%'
