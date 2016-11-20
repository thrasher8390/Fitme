# FitMe DataBase Design
## Background
The Database is held in a MySQL format
## Architecture
|	Table		|	Columns	|	Resource	|
|	:---:		|	:---:	|	:---:		|
|	User		|	UserName, Password, UserProfile |[User Model](../Models/UserModel/Controller/UserModel.cs)|
|	Clothes?	|	||
|	Top			|	Validation, Designer, Neck Size, Sleeve Size, Chest Size , CreatedByUser	|[Top Model](../Models/ClothesModel/TopModel/Controller/TopModel.cs)|
|	Designer	|	Name	||
|	Sizes		|	Size	||