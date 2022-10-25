-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SpInsertContacts
	-- Add the parameters for the stored procedure here
	@PhoneNumber char(11)
	,@LName nvarchar(50)
	,@FName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	INSERT INTO [dbo].[Contacts]
        ([FName]
        ,[LName]
        ,[PhoneNumber])
     VALUES
        (@FName,@LName,@PhoneNumber)


END
