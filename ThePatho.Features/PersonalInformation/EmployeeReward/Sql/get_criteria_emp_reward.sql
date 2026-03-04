SELECT 
    r.EmRewardID,
    r.LetterNo,
    r.EmployeeID,

    emp.EmployeeNo,
    emp.Fullname as EmployeeName,
    emp.PositionCode,
    pos.PositionName,

    CONVERT(VARCHAR, r.LetterDate, 106) AS LetterDate,
    r.RewardTypeCode,
    r.Remarks,
    r.CurrencyCode,
    r.Amount,
    r.Attachment,
    r.IsDeleted,
    r.InsertedBy,
    CONVERT(VARCHAR, r.InsertedDate, 106) AS InsertedDate,
    r.ModifiedBy,
    CONVERT(VARCHAR, r.ModifiedDate, 106) AS ModifiedDate

FROM dbo.TEPDEmployeeReward r
INNER JOIN TEPMEmployee emp 
    ON r.EmployeeID = emp.EmployeeID
LEFT JOIN TOGMPosition pos 
    ON emp.PositionCode = pos.PositionCode

WHERE
    (@EmployeeId = 0 OR r.EmployeeID = @EmployeeId)
    AND
    (
        @LetterNo IS NULL OR @LetterNo = ''
        OR r.LetterNo LIKE '%' + @LetterNo + '%'
    )
    AND
    (
        @RewardTypeCode IS NULL OR @RewardTypeCode = ''
        OR r.RewardTypeCode LIKE '%' + @RewardTypeCode + '%'
    )