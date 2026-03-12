DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    PunishmentCode,
    PunishmentName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMPunishmentType
WHERE
    (@PunishmentCode IS NULL OR PunishmentCode LIKE '%' + @PunishmentCode + '%') AND
    (@PunishmentName IS NULL OR PunishmentName LIKE '%' + @PunishmentName + '%') 
ORDER BY
    CASE WHEN @SortBy = 'PunishmentCode' THEN PunishmentCode END,
    CASE WHEN @SortBy = 'PunishmentName' THEN PunishmentName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;