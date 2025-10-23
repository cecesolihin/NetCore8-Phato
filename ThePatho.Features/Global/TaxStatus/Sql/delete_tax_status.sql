UPDATE
    dbo.TGEMTaxStatus
SET IsDelete = 1
WHERE
    TaxStatusCode = @TaxStatusCode