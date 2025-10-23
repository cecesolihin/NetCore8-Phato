IF (@Action = 'ADD')
BEGIN
    INSERT INTO dbo.TGEMDInventoryGroupOrg
    (
        InventoryGroupCode,
        OrganizationCode,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @InventoryGroupCode,
        @OrganizationCode,
        @User,
        GETDATE()
    );
END
ELSE IF (@Action = 'EDIT')
BEGIN
    UPDATE dbo.TGEMDInventoryGroupOrg
    SET
        InventoryGroupCode = @InventoryGroupCode,
        OrganizationCode   = @OrganizationCode,
        ModifiedBy      = @User,
        ModifiedDate    = GETDATE()
    WHERE
        BloodTypeCode = @BloodTypeCode;
END	