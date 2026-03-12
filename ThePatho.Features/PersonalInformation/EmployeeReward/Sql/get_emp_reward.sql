DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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
        @Reward IS NULL OR @Reward = ''
        OR r.RewardTypeCode LIKE '%' + @Reward + '%'
        OR r.LetterNo LIKE '%' + @Reward + '%'
        OR emp.EmployeeNo LIKE '%' + @Reward + '%'
        OR emp.Fullname LIKE '%' + @Reward + '%'
        OR pos.PositionName LIKE '%' + @Reward + '%'
    )
     -- Letter Date Range
    AND (@LetterDateFrom IS NULL OR r.LetterDate >= @LetterDateFrom)
    AND (@LetterDateTo IS NULL OR r.LetterDate < DATEADD(DAY,1,@LetterDateTo))
    AND r.IsDeleted = 0

ORDER BY
    CASE WHEN @SortBy = 'LetterNo' AND @OrderBy = 'ASC' THEN r.LetterNo END ASC,
    CASE WHEN @SortBy = 'LetterNo' AND @OrderBy = 'DESC' THEN r.LetterNo END DESC,

    CASE WHEN @SortBy = 'RewardTypeCode' AND @OrderBy = 'ASC' THEN r.RewardTypeCode END ASC,
    CASE WHEN @SortBy = 'RewardTypeCode' AND @OrderBy = 'DESC' THEN r.RewardTypeCode END DESC,

    CASE WHEN @SortBy = 'LetterDate' AND @OrderBy = 'ASC' THEN r.LetterDate END ASC,
    CASE WHEN @SortBy = 'LetterDate' AND @OrderBy = 'DESC' THEN r.LetterDate END DESC,

    CASE WHEN @SortBy = 'InsertedDate' AND @OrderBy = 'ASC' THEN r.InsertedDate END ASC,
    CASE WHEN @SortBy = 'InsertedDate' AND @OrderBy = 'DESC' THEN r.InsertedDate END DESC,

    CASE WHEN @SortBy = 'ModifiedDate' AND @OrderBy = 'ASC' THEN r.ModifiedDate END ASC,
    CASE WHEN @SortBy = 'ModifiedDate' AND @OrderBy = 'DESC' THEN r.ModifiedDate END DESC

OFFSET @Offset ROWS 
FETCH NEXT @PageSize ROWS ONLY;