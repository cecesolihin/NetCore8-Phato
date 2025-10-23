SELECT 
    EmPunishmentID,
    LetterNo,
    EmployeeID,
     CONVERT(VARCHAR, LetterDate, 106) AS LetterDate,  -- dd MMM yyyy LetterDate,
    PunishmentType,
     CONVERT(VARCHAR, ValidFrom, 106) AS ValidFrom,  -- dd MMM yyyy ValidFrom,
     CONVERT(VARCHAR, ValidTo, 106) AS ValidTo,  -- dd MMM yyyy ValidTo,
     CONVERT(VARCHAR, RecoveryDate, 106) AS RecoveryDate,  -- dd MMM yyyy RecoveryDate,
    Remarks,
    Attachment,
    IsDeleted,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate   -- dd MMM yyyy
FROM 
    dbo.TEPDEmployeePunishment
WHERE
    (@LetterNo = '' OR LetterNo LIKE '%' + @LetterNo + '%') AND
    (@EmployeeId IS NULL OR EmployeeID = @EmployeeId) AND
    (@LetterDate = '' OR CONVERT(VARCHAR(10), LetterDate, 120) = @LetterDate) AND
    (@PunishmentType = '' OR PunishmentType LIKE '%' + @PunishmentType + '%') AND
    (IsDeleted = 0 OR IsDeleted IS NULL)