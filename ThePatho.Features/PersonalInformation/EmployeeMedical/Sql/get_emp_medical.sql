DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

SELECT 
    EmployeeID,
    DiseaseCategoryCode,
    DiseaseName,
    StartDate,
    EndDate,
    Therapy,
    Hospital,
    CountryId,
    ProvinceId,
    CityId,
    Doctor,
    Phone,
    Remarks,
    TimeIn,
    TimeOut,
    Obat,
    TindakanPertama,
    TindakanKedua,
    IsDeleted,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate
FROM 
    dbo.TEPDEmployeeMedical
WHERE
    (@EmployeeId > 0 OR EmployeeID = @EmployeeId) AND
    (
        @Medical IS NULL OR @Medical = ''
        OR Hospital LIKE '%' + @Medical + '%'
        OR DiseaseName LIKE '%' + @Medical + '%'
    ) AND
    (IsDeleted = 0 OR IsDeleted IS NULL)
ORDER BY
    CASE WHEN @SortBy = 'DiseaseName' AND @OrderBy = 'ASC' THEN DiseaseName END ASC,
    CASE WHEN @SortBy = 'DiseaseName' AND @OrderBy = 'DESC' THEN DiseaseName END DESC,
    CASE WHEN @SortBy = 'StartDate' AND @OrderBy = 'ASC' THEN StartDate END ASC,
    CASE WHEN @SortBy = 'StartDate' AND @OrderBy = 'DESC' THEN StartDate END DESC,
    CASE WHEN @SortBy = 'Hospital' AND @OrderBy = 'ASC' THEN Hospital END ASC,
    CASE WHEN @SortBy = 'Hospital' AND @OrderBy = 'DESC' THEN Hospital END DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
