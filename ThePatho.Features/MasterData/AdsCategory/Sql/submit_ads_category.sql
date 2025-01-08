IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TMAdsCategory (ads_category_code, ads_category_name, inserted_by, inserted_date)
    VALUES (@AdsCategoryCode, @AdsCategoryName, @User, GETDATE());
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TMAdsCategory
    SET ads_category_name = @AdsCategoryName,
        modified_by = @User,
        modified_date = GETDATE()
    WHERE ads_category_code = @AdsCategoryCode;
END