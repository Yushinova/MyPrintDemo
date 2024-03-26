create table Products
(
ID_product int not null primary key identity(1,1),
Name_product varchar(50) not null,
Count_product int not null,
Cost_product money not null,
IsActuality bit not null DEFAULT (1)
)
go
create table Images
(
ID_image int not null primary key identity(1,1),
Url varchar(100),
Product_ID int foreign key references Products(ID_product)
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
Cost_order money,
Date_order datetime not null,
IsPaid bit not null DEFAULT (0),
IsProduction bit not null DEFAULT (0),
IsReady bit not null DEFAULT (0),
User_ID int foreign key references Users(ID_user)
)
go
create table Orders_Products
(
ID int not null primary key identity(1,1),
Product_ID int foreign key references Products(ID_product),
Order_ID int foreign key references Orders(ID_order)
)
go
create table Payments
(
ID_payment int not null primary key identity(1,1),
Sum_payment money not null,
Date_payment datetime not null,
Order_ID int foreign key references Orders(ID_order)
)
go
insert into Users(Password,Login, Name, Surname, Phone)
values('110484tanya', 'sulin_art@mail.ru', 'Tanya', 'Yushinova', '8-905-45-46-999'),
('208574yuy','krecker@gmail.com','Vasya','Pupkin','8-900-526-33-11')
go
select *from Users
go
insert into Products(Name_product, Count_product, Cost_product)
values ('business cards',1000,1800),
('business cards',2000,2800),
('flyers А6',1000,1200),
('flyers А6',2000,2100),
('flyers А4',1000, 2400)
go
select *from Products
go
insert into Orders (Cost_order, Date_order, User_ID)
values(3000, getdate(), 1),
(2400, getdate(), 2)
go
insert into Orders_Products(Product_ID,Order_ID)
values(3,1),(1,1), (1,2), (1,2)
go
select u.Name,o.ID_order, o.Date_order, p.Name_product, p.Cost_product from Users u join Orders o on u.ID_user=o.user_ID
join Orders_Products op on op.Order_ID=o.ID_order
join Products p on p.ID_product=op.Product_ID
where u.Name like 'Tanya'
