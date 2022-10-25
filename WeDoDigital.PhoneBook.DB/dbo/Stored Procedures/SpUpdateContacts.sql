-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE SpUpdateContacts
	-- Add the parameters for the stored procedure here
	@ContactID INT
	,@FName nvarchar(50)
	,@LName Nvarchar(50)
	,@PhoneNumber CHAR(11)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE C SET
		FName = @FName
		,LName = @LName
		,PhoneNumber = @PhoneNumber
	from contacts C
	WHERE c.ID = @ContactID

END
