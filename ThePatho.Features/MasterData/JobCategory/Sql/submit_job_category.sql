IF (@Action = 'ADD')
BEGIN
    INSERT INTO [dbo].[TMJobCategory] (
        [job_category_code],
        [job_category_name],
        [is_category],
        [parent_category],
        [inserted_by],
        [inserted_date]
    )
    VALUES (
        @JobCategoryCode,
        @JobCategoryName,
        @IsCategory,
        @ParentCategory,
        @User,
        GETDATE()
    )
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE [dbo].[TMJobCategory]
    SET 
        [job_category_name] = @JobCategoryName,
        [is_category] = @IsCategory,
        [parent_category] = @ParentCategory,
        [modified_by] = @User,
        [modified_date] = GETDATE()
    WHERE [job_category_code] = @JobCategoryCode
END
