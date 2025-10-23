DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    RoomCode,
    RoomName,
    BuildingCode,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMRoom
WHERE
   (@RoomCode IS NULL OR RoomCode LIKE '%' + @RoomCode + '%') AND
    (@BuildingCode IS NULL OR BuildingCode LIKE '%' + @BuildingCode + '%') AND
    (@RoomName IS NULL OR RoomName LIKE '%' + @RoomName + '%')
ORDER BY
    CASE WHEN @SortBy = 'RoomCode' THEN RoomCode END,
    CASE WHEN @SortBy = 'RoomName' THEN RoomName END,
    CASE WHEN @SortBy = 'BuildingCode' THEN RoomName END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;