IF @Action = 'ADD'
BEGIN
    INSERT INTO dbo.TEPDEmployeeIdentity
    (
        EmployeeID,
        IdentityCode,
        CompanyCode,
        IdentityNo,
        IssuedDate,
        ExpiredDate,
        FileUpload,
        Remarks,
        FileFullPath,
        FileName,
        IsDeleted,
        InsertedBy,
        InsertedDate
    )
    VALUES
    (
        @EmployeeId,
        @IdentityCode,
        @CompanyCode,
        @IdentityNo,
        @IssuedDate,
        @ExpiredDate,
        @FileUpload,
        @Remarks,
        @FileFullPath,
        @FileName,
        0,
        @User,
        GETDATE()
    );
END
ELSE IF @Action = 'EDIT'
BEGIN
    UPDATE dbo.TEPDEmployeeIdentity
    SET
        CompanyCode = @CompanyCode,
        IdentityNo = @IdentityNo,
        IssuedDate = @IssuedDate,
        ExpiredDate = @ExpiredDate,
        FileUpload = @FileUpload,
        Remarks = @Remarks,
        FileFullPath = @FileFullPath,
        FileName = @FileName,
        ModifiedBy = @User,
        ModifiedDate = GETDATE()
    WHERE EmployeeID = @EmployeeId AND IdentityCode = @IdentityCode;
END

