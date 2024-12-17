SELECT 
    quest_detail_id AS QuestionDetailId,
    questionnaire_code AS QuestionnaireCode

FROM [DB_TRIAL].[dbo].[TMQuestionSettingDetail]
WHERE
    (@QuestionCode IS NULL OR questionnaire_code LIKE '%' + @QuestionCode + '%') 

