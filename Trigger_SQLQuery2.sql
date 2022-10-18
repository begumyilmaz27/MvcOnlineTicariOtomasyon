create trigger SatisStokAzalt
on SalesMovements
After insert 
as
declare @ProductID int
declare @SalesMovement_Piece int
select @ProductID=ProductID, @SalesMovement_Piece=SalesMovement_Piece from inserted
update Products set ProductStock=ProductStock-@SalesMovement_Piece where ProductID=@ProductID