UPDATE 
    dbo.TGEMProvince
SET IsDeleted = 1
WHERE
    ProvinceId = @ProvinceId