DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    InventoryGroupCode,
    OrganizationCode,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMDInventoryGroupOrg
WHERE
    (@InventoryGroupCode IS NULL OR InventoryGroupCode LIKE '%' + @InventoryGroupCode + '%') AND
    (@OrganizationCode IS NULL OR OrganizationCode LIKE '%' + @OrganizationCode + '%') 
ORDER BY
    CASE WHEN @SortBy = 'InventoryGroupCode' THEN BloodTypeCode END,
    CASE WHEN @SortBy = 'OrganizationCode' THEN BloodTypeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;