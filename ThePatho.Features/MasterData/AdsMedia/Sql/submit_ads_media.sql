IF (@Action = 'ADD')
BEGIN
    INSERT INTO [dbo].[TMAdsMedia] (
        [ads_code],
        [ads_name],
        [ads_category_code],
        [phone],
        [contact_person],
        [remarks],
        [use_recruitment_fee],
        [recruitment_fee],
        [recruitment_fee_2],
        [recruitment_fee_3],
        [inserted_by],
        [inserted_date]
    )
    VALUES (
        @AdsCode,
        @AdsName,
        @AdsCategoryCode,
        @Phone,
        @ContactPerson,
        @Remarks,
        @UseRecruitmentFee,
        @RecruitmentFee,
        @RecruitmentFee2,
        @RecruitmentFee3,
        @User,
        GETUTCDATE()
    )
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE [dbo].[TMAdsMedia]
    SET 
        [ads_name] = @AdsName,
        [ads_category_code] = @AdsCategoryCode,
        [phone] = @Phone,
        [contact_person] = @ContactPerson,
        [remarks] = @Remarks,
        [use_recruitment_fee] = @UseRecruitmentFee,
        [recruitment_fee] = @RecruitmentFee,
        [recruitment_fee_2] = @RecruitmentFee2,
        [recruitment_fee_3] = @RecruitmentFee3,
        [modified_by] = @User,
        [modified_date] = GETUTCDATE()
    WHERE [ads_code] = @AdsCode
END
