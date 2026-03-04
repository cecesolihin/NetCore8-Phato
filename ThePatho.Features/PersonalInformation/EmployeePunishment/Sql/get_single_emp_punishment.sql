SELECT 
    p.EmPunishmentID,
    p.LetterNo,
    p.EmployeeID,

    emp.EmployeeNo,
    emp.Fullname as EmployeeName,
    emp.PositionCode,
    pos.PositionName,

    CONVERT(VARCHAR, p.LetterDate, 106) AS LetterDate,
    p.PunishmentType,
    CONVERT(VARCHAR, p.ValidFrom, 106) AS ValidFrom,
    CONVERT(VARCHAR, p.ValidTo, 106) AS ValidTo,
    CONVERT(VARCHAR, p.RecoveryDate, 106) AS RecoveryDate,

    p.Remarks,
    p.Attachment,
    p.IsDeleted,
    p.InsertedBy,
    CONVERT(VARCHAR, p.InsertedDate, 106) AS InsertedDate,
    p.ModifiedBy,
    CONVERT(VARCHAR, p.ModifiedDate, 106) AS ModifiedDate

FROM dbo.TEPDEmployeePunishment p
INNER JOIN TEPMEmployee emp 
    ON p.EmployeeID = emp.EmployeeID
LEFT JOIN TOGMPosition pos 
    ON emp.PositionCode = pos.PositionCode

WHERE 
    p.EmPunishmentID = @EmPunishmentId
    AND ISNULL(p.IsDeleted, 0) = 0;