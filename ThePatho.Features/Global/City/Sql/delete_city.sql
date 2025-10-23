UPDATE 
    dbo.TGEMCity
SET IsDeleted =1
WHERE
    CityId = @CityId