DECLARE @Offset INT = @PageNumber * @PageSize;
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
    (@QuestionCode IS NULL OR questionnaire_code LIKE '%' + @QuestionCode + '%') AND
    (@QuestionName IS NULL OR questionnaire_name LIKE '%' + @QuestionName + '%') 
    ORDER BY
    CASE WHEN @SortBy = 'QuestionnaireCode' THEN online_test_code END,
    CASE WHEN @SortBy = 'QuestionnaireName' THEN questionnaire_name END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, inserted_date, 120) END
    , CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
      END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;