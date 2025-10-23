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