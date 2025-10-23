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
    cc.CapColorId =@CapColorId