DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    EmployeeID,
    IdentityCode,
    CompanyCode,
    IdentityNo,
    CONVERT(VARCHAR, IssuedDate, 106) AS IssuedDate,   -- dd MMM yyyy
    CONVERT(VARCHAR, ExpiredDate, 106) AS ExpiredDate, -- dd MMM yyyy
    Remarks,
    FileName,
    FileFullPath,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate
FROM 
    dbo.TEPDEmployeeIdentity
WHERE
    (@EmployeeId > 0 AND EmployeeID = @EmployeeId) AND
    (
        @Identity IS NULL OR @Identity = '' 
        OR IdentityCode LIKE '%' + @Identity + '%'
        OR IdentityNo LIKE '%' + @Identity + '%'
    ) AND
    (IsDeleted = 0)
ORDER BY
    CASE 
        WHEN @SortBy = 'IdentityNo' AND @OrderBy = 'ASC' THEN IdentityNo
    END ASC,
    CASE 
        WHEN @SortBy = 'IdentityNo' AND @OrderBy = 'DESC' THEN IdentityNo
    END DESC,
    CASE 
        WHEN @SortBy = 'IdentityCode' AND @OrderBy = 'ASC' THEN IdentityCode
    END ASC,
    CASE 
        WHEN @SortBy = 'IdentityCode' AND @OrderBy = 'DESC' THEN IdentityCode
    END DESC,
    CASE 
        WHEN @SortBy = 'IssuedDate' AND @OrderBy = 'ASC' THEN IssuedDate
    END ASC,
    CASE 
        WHEN @SortBy = 'IssuedDate' AND @OrderBy = 'DESC' THEN IssuedDate
    END DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
