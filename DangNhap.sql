USE QuanLyFotos
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Dang_nhap
	@username NVARCHAR(255),
	@hashed_pass CHAR(64)
AS
BEGIN
    DECLARE @count INT
    DECLARE @res BIT
    SELECT @count = COUNT(*) FROM dbo.Nguoi_dung WHERE ten_nguoi_dung = @username AND mat_khau_hashed = @hashed_pass
	IF @count > 0
		SET @res = 1
	ELSE
		SET @res = 0

	SELECT @res
END
