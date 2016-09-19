<Query Kind="Statements">
  <Connection>
    <ID>a0fbdd7c-e462-4d5c-b70a-cfdc4359136b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var maxbills = (from x in Waiters
				select x.Bills.Count()).Max();
var BestWaiter = from x in Waiters 
				//where x.Bills.Count() == maxbills
				select new {
					Name = x.FirstName + " " + x.LastName,
					tBills = x.Bills.Count()
					};
				
BestWaiter.Dump();

var WaiterBills = from x in Waiters where x.Bills.Count() == 
						(from y in Waiters select y.Bills.Count()).Max()
						select new {
							First_Name = x.FirstName,
							Last_Name = x.LastName,
							Bill_Count = x.Bills.Count()
						};
						
WaiterBills.Dump();

//create a dataset which contains the summary bill info by waiter

var WaiterBills = from x in Waiters
	orderby x.LastName, x.FirstName
	select new{
		Name = x.LastName + ", " + x.FirstName,
		BillInfo = (from y in x.Bills
					where y.BillItems.Count() > 0
					select new{
						BillID = y.BillID,
						BillDate = y.BillDate,
						TableID = y.TableID,
						Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
						
					}
					)
	};
	
WaiterBills.Dump();
