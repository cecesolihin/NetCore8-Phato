DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
    (@AnnounceContent IS NULL OR AnnounceContent LIKE '%' + @AnnounceContent + '%') AND
    (@Status IS NULL OR Status = @Status)
ORDER BY
    CASE WHEN @SortBy = 'AnnounceSubject' THEN AnnounceSubject END,
    CASE WHEN @SortBy = 'AnnounceContent' THEN AnnounceContent END,
    CASE WHEN @SortBy = 'Status' THEN Status END,
    CASE WHEN @SortBy = 'InsertedDate' THEN CONVERT(DATETIME, InsertedDate, 120) END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN CONVERT(DATETIME, ModifiedDate, 120) END,
    CASE @OrderBy
        WHEN 'ASC' THEN 1
        WHEN 'DESC' THEN -1
    END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;