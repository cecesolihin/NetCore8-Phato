IF (@Action = 'ADD')
BEGIN
    INSERT INTO [dbo].[TMQuestionSettingDetail] (
        [questionnaire_code],
        [is_category],
        [question],
        [quest_parent],
        [scoring_code],
        [order],
        [attachment],
        [multi_choice_option],
        [correct_answer],
        [weight_point],
        [inserted_by],
        [inserted_date]
    )
    VALUES (
        @QuestionnaireCode,
        @IsCategory,
        @Question,
        @QuestParent,
        @ScoringCode,
        @Order,
        @Attachment,
        @MultiChoiceOption,
        @CorrectAnswer,
        @WeightPoint,
        @User,
        GETDATE()
    )
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE [dbo].[TMQuestionSettingDetail]
    SET 
        [questionnaire_code] = @QuestionnaireCode,
        [is_category] = @IsCategory,
        [question] = @Question,
        [quest_parent] = @QuestParent,
        [scoring_code] = @ScoringCode,
        [order] = @Order,
        [attachment] = @Attachment,
        [multi_choice_option] = @MultiChoiceOption,
        [correct_answer] = @CorrectAnswer,
        [weight_point] = @WeightPoint,
        [modified_by] = @User,
        [modified_date] = GETDATE()
    WHERE [quest_detail_id] = @QuestDetailId
END
