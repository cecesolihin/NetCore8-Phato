SELECT 
    ed.EmployeeDocumentId,
    ed.EmployeeID,
    ed.DocumentTypeCode,
    ed.FilePath,
    ed.Remark,
    ed.InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,--ed.InsertedDate,
    ed.ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate--ed.ModifiedDate
FROM TEPDEmployeeDocument ed
WHERE 1=1
  AND (@EmployeeId > 0 AND ed.EmployeeID = @EmployeeId)
  AND (@DocumentType = '' OR ed.DocumentTypeCode = @DocumentType)
ORDER BY
    CASE 
        WHEN @SortBy = 'DocumentTypeCode' AND @OrderBy = 'ASC' THEN ed.DocumentTypeCode
    END ASC,
    CASE 
        WHEN @SortBy = 'DocumentTypeCode' AND @OrderBy = 'DESC' THEN ed.DocumentTypeCode
    END DESC,
    CASE 
        WHEN @SortBy = 'InsertedDate' AND @OrderBy = 'ASC' THEN CONVERT(NVARCHAR, ed.InsertedDate)
    END ASC,
    CASE 
        WHEN @SortBy = 'InsertedDate' AND @OrderBy = 'DESC' THEN CONVERT(NVARCHAR, ed.InsertedDate)
    END DESC
OFFSET (@PageNumber - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;
