DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

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

WHERE 1=1

    AND (@EmployeeId = 0
        OR p.EmployeeID = @EmployeeId)

    AND (
        @Punishment IS NULL OR @Punishment = ''
        OR p.PunishmentType LIKE '%' + @Punishment + '%'
        OR p.LetterNo LIKE '%' + @Punishment + '%'
    )
    -- Letter Date Range
    AND (@LetterDateFrom IS NULL OR p.LetterDate >= @LetterDateFrom)
    AND (@LetterDateTo IS NULL OR p.LetterDate < DATEADD(DAY,1,@LetterDateTo))

    -- Valid Date Range
    AND (@ValidFrom IS NULL OR p.ValidFrom >= @ValidFrom)
    AND (@ValidTo IS NULL OR p.ValidTo < DATEADD(DAY,1,@ValidTo))

    -- Recovery Date Range
    AND (@RecoveryDateFrom IS NULL OR p.RecoveryDate >= @RecoveryDateFrom)
    AND (@RecoveryDateTo IS NULL OR p.RecoveryDate < DATEADD(DAY,1,@RecoveryDateTo))


    AND ISNULL(p.IsDeleted,0) = 0

ORDER BY
    CASE WHEN @SortBy = 'LetterNo' AND @OrderBy = 'ASC' THEN p.LetterNo END ASC,
    CASE WHEN @SortBy = 'LetterNo' AND @OrderBy = 'DESC' THEN p.LetterNo END DESC,

    CASE WHEN @SortBy = 'PunishmentType' AND @OrderBy = 'ASC' THEN p.PunishmentType END ASC,
    CASE WHEN @SortBy = 'PunishmentType' AND @OrderBy = 'DESC' THEN p.PunishmentType END DESC,

    CASE WHEN @SortBy = 'LetterDate' AND @OrderBy = 'ASC' THEN p.LetterDate END ASC,
    CASE WHEN @SortBy = 'LetterDate' AND @OrderBy = 'DESC' THEN p.LetterDate END DESC,

    CASE WHEN @SortBy = 'InsertedDate' AND @OrderBy = 'ASC' THEN p.InsertedDate END ASC,
    CASE WHEN @SortBy = 'InsertedDate' AND @OrderBy = 'DESC' THEN p.InsertedDate END DESC,

    CASE WHEN @SortBy = 'ModifiedDate' AND @OrderBy = 'ASC' THEN p.ModifiedDate END ASC,
    CASE WHEN @SortBy = 'ModifiedDate' AND @OrderBy = 'DESC' THEN p.ModifiedDate END DESC

OFFSET @Offset ROWS 
FETCH NEXT @PageSize ROWS ONLY;
