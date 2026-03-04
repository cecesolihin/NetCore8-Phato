SELECT 
    DocumentTypeCode,
    DocumentTypeName,
    InsertedBy,
    CONVERT(VARCHAR, InsertedDate, 106) AS InsertedDate,  -- dd MMM yyyy
    ModifiedBy,
    CONVERT(VARCHAR, ModifiedDate, 106) AS ModifiedDate  -- dd MMM yyyy

FROM 
    dbo.TGEMDocumentType
WHERE
    (@DocumentTypeCode IS NULL OR DocumentTypeCode LIKE '%' + @DocumentTypeCode + '%') AND
    (@DocumentTypeName IS NULL OR DocumentTypeName LIKE '%' + @DocumentTypeName + '%') 