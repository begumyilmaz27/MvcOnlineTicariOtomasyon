create trigger tutarekle
on Bill_Item
after insert
as
declare @BillID int
declare @BillQuantity decimal (18,2)
select @BillID=BillID,@BillQuantity=billQuantity from inserted
update Bills set Total=Total+@BillQuantity where BillID=@BillID