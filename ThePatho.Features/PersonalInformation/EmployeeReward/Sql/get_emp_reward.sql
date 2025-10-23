DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
    (@EmployeeId = 0 OR EmployeeID = @EmployeeId) AND
    (@LetterNo = '' OR LetterNo LIKE '%' + @LetterNo + '%') AND
    (@RewardTypeCode = '' OR RewardTypeCode LIKE '%' + @RewardTypeCode + '%') AND
    IsDeleted = 0
ORDER BY
    CASE WHEN @SortBy = 'LetterNo' THEN LetterNo END,
    CASE WHEN @SortBy = 'RewardTypeCode' THEN RewardTypeCode END,
    CASE WHEN @SortBy = 'LetterDate' THEN LetterDate END,
    CASE WHEN @SortBy = 'InsertedDate' THEN InsertedDate END,
    CASE WHEN @SortBy = 'ModifiedDate' THEN ModifiedDate END
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
