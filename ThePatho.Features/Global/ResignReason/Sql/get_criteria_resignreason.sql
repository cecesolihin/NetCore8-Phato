SELECT 
    ResignReasonCode,
    ResignReasonName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMResignReason
WHERE
    (@ResignReasonCode IS NULL OR ResignReasonCode LIKE '%' + @ResignReasonCode + '%') AND
    (@ResignReasonName IS NULL OR ResignReasonName LIKE '%' + @ResignReasonName + '%')