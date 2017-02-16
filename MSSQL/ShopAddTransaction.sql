CREATE PROCEDURE BuyProduct 
@ProductId int, @Count int
AS BEGIN
BEGIN TRANSACTION
IF @Count > (SELECT * FROM [dbo].Products WHERE Id = @ProductId)
ROLLBACK TRANSACTION 
ELSE 
UPDATE [dbo].Products
SET Count = Count - @Count
WHERE Id = @ProductId
IF @@ERROR = 0
COMMIT
ELSE 
ROLLBACK
END
