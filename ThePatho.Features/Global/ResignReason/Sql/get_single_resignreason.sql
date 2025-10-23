SELECT 
    ResignReasonCode,
    ResignReasonName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate

FROM 
    dbo.TGEMResignReason
WHERE
    ResignReasonCode = @ResignReasonCode