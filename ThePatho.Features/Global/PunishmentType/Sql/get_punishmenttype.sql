DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    PunishmentTypeCode,
    PunishmentTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMPunishmentType
WHERE
    (@PunishmentTypeCode IS NULL OR PunishmentTypeCode LIKE '%' + @PunishmentTypeCode + '%') AND
    (@PunishmentTypeName IS NULL OR PunishmentTypeName LIKE '%' + @PunishmentTypeName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'PunishmentTypeCode' THEN PunishmentTypeCode END,
    CASE WHEN @SortBy = 'PunishmentTypeName' THEN PunishmentTypeName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;