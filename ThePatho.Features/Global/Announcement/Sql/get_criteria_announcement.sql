
SELECT 
    AnnouncementID,
    AnnounceSubject,
    AnnounceImage,
    Attachment,
    AnnounceContent,
    Status,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate,  -- dd MMM yyyy
    ActiveStatus
FROM 
    dbo.TGEMAnnouncement
WHERE
    (@AnnounceSubject IS NULL OR AnnounceSubject LIKE '%' + @AnnounceSubject + '%') AND
    (@Status IS NULL OR Status = @Status)
