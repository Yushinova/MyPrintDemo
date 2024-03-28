create table Products
(
ID_product int not null primary key identity(1,1),
Name_product varchar(50) not null,
Heigh int not null,
Width int not null,
Count_product int not null,
Cost_product money not null,
IsActuality bit not null DEFAULT (1)
)
go
create table Users
(
ID_user int not null primary key identity(1,1),
Password varchar(50) not null,
Login varchar(50) not null unique,
Name varchar(50) not null,
Surname varchar(50) not null,
Phone varchar(50) not null unique
)
go
create table Orders
(
ID_order int not null primary key identity(1,1),
Date_order datetime not null,
IsPaid bit not null DEFAULT (0),
IsProduction bit not null DEFAULT (0),
IsReady bit not null DEFAULT (0),
User_ID int foreign key references Users(ID_user),
Product_ID int foreign key references Products(ID_product)
)
go
create table Images
(
ID_image int not null primary key identity(1,1),
Url varchar(100),
Order_ID int foreign key references Orders(ID_Order)
)
go
create table Payments
(
ID_payment int not null primary key identity(1,1),
Sum_payment money not null,
Date_payment datetime not null,
Order_ID int foreign key references Orders(ID_order)
)