SELECT 
    EmRewardID,
    LetterNo,
    EmployeeID,
     CONVERT(VARCHAR, LetterDate, 106) AS LetterDate,  -- dd MMM yyyy LetterDate,
    RewardTypeCode,
    Remarks,
    CurrencyCode,
    Amount,
    Attachment,
    IsDeleted,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate   -- dd MMM yyyy
FROM 
    dbo.TEPDEmployeeReward
WHERE
    EmRewardID = @EmRewardId;