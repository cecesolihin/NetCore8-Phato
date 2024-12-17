SELECT 
    quest_detail_id AS QuestionDetailId,
    questionnaire_code AS QuestionnaireCode,
    is_category AS IsCategory,
    question AS QuestionText,
    quest_parent AS ParentQuestion,
    scoring_code AS ScoringCode,
    [order] AS QuestionOrder,
    attachment AS Attachment,
    multi_choice_option AS MultiChoiceOption,
    correct_answer AS CorrectAnswer,
    weight_point AS WeightPoint,
    inserted_by AS InsertedBy,
    CONVERT(VARCHAR(19), inserted_date, 120) AS InsertedDate,   -- Format: YYYY-MM-DD HH:MM:SS
    modified_by AS ModifiedBy,
    CONVERT(VARCHAR(19), modified_date, 120) AS ModifiedDate    -- Format: YYYY-MM-DD HH:MM:SS
FROM [DB_TRIAL].[dbo].[TMQuestionSettingDetail]
WHERE
questionnaire_code = @QuestionCode

