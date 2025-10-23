SELECT
    cc.CapColorId,
    cc.ColorName,
    cc.InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,--cc.InsertedDate,
    cc.ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate,--cc.ModifiedDate,
    cc.IsDeleted
FROM
    TEPMEmployeeCapColor cc
WHERE
    cc.IsDeleted = 0
    AND (@ColorName = '' OR cc.ColorName LIKE '%' + @ColorName + '%')
ORDER BY
    CASE WHEN @OrderBy = 'ASC' THEN
        CASE 
            WHEN @SortBy = 'ColorName' THEN cc.ColorName
            WHEN @SortBy = 'InsertedDate' THEN CONVERT(NVARCHAR, cc.InsertedDate, 120)
        END
    END ASC,
    CASE WHEN @OrderBy = 'DESC' THEN
        CASE 
            WHEN @SortBy = 'ColorName' THEN cc.ColorName
            WHEN @SortBy = 'InsertedDate' THEN CONVERT(NVARCHAR, cc.InsertedDate, 120)
        END
    END DESC
OFFSET (@PageNumber - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;