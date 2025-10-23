IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMAnnouncement
    (
        AnnounceSubject,
        AnnounceImage,
        Attachment,
        AnnounceContent,
        Status,
        ActiveStatus,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @AnnounceSubject,
        @AnnounceImage,
        @Attachment,
        @AnnounceContent,
        @Status,
        @ActiveStatus,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMAnnouncement
    SET
        AnnounceSubject = @AnnounceSubject,
        AnnounceImage   = @AnnounceImage,
        Attachment      = @Attachment,
        AnnounceContent = @AnnounceContent,
        Status          = @Status,
        ActiveStatus    = @ActiveStatus,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        AnnouncementID = @AnnouncementId;
END
