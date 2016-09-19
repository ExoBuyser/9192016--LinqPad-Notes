<Query Kind="Statements">
  <Connection>
    <ID>2e41785e-80b6-4447-a98e-fc24a0d3fa14</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//When you need to use multiple steps to solve a proble, 
//switch your Language choice to either 
//statement or program

//the result of each query will now be save in a variable
//the variable can then be used in future queries

var maxcount = (from x in MediaTypes
	select x.Tracks.Count()).Max();
	
//to display the contents of a variable in LinqPad
//you use the method .Dump()

maxcount.Dump();


//use a value in a preceeding create variable
var popularMediaType = from x in MediaTypes where x.Tracks.Count() == maxcount
						select new {
							Type = x.Name,
							TCount = x.Tracks.Count()
							
						};
						
popularMediaType.Dump();

//can this set of statements be done as one complete query
//the answer is possibly, and in this case yes
//in this example maxcount could be exchanged for the query
//that actually create the value in the First place
//This subsitituted
var popularMediaTypeSubQuery = from x in MediaTypes where x.Tracks.Count() == 
						(from y in MediaTypes select y.Tracks.Count()).Max()
						select new {
							Type = x.Name,
							TCount = x.Tracks.Count()
							
						};
						
popularMediaTypeSubQuery.Dump();


//
//
var popularMediaTypeSubMethod = from x in MediaTypes where x.Tracks.Count() == 
						MediaTypes.Select (mt => mt.Tracks.Count()).Max()
						select new {
							Type = x.Name,
							TCount = x.Tracks.Count()
							
						};
						
popularMediaTypeSubMethod.Dump();