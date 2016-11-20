
# Exceptions
I'd like to keep track of all the exceptions in a list so that in the future we can just report back error codes and log in a file for the engineer to decipher
## List
|	ID #	|	Class			| Text	|  
|	:---:	|	:---:			| :---:	|  
|	0x0000	|	TopModel.cs		|	When reading for the colum there was more than 1 id with the filtered value|
|	0x0001	|	UserModel.cs	|	When signing in we found repeat emails in DB|
|	0x0002	|	UserProfile.aspx|	Failure displaying user profile because user is incomplete|
|	0x0003	|	DataBase.cs		|	Database is not responding|
|	0x0004	|	DataBase.cs		|	Failed to ReadFromTable|
|	0x0005	|	TopModel.cs		|	Try Removing Top Failed|
|	0x0006	|	DataBase.cs		|	Unable to close the DB connection|
|	0x0007	|	RateItem.aspx.cs|	Could not convert price to a type Double |
|	0x0008	|	DataBase.cs		|	Unable to update Colum |