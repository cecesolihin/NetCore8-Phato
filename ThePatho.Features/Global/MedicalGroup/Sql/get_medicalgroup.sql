DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    MedicalGroupCode,
    MedicalGroupName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMMedicalGroup
WHERE
    (@MedicalGroupCode IS NULL OR MedicalGroupCode LIKE '%' + @MedicalGroupCode + '%') AND
    (@MedicalGroupName IS NULL OR MedicalGroupName LIKE '%' + @MedicalGroupName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'MedicalGroupCode' THEN MedicalGroupCode END,
    CASE WHEN @SortBy = 'MedicalGroupName' THEN MedicalGroupName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
