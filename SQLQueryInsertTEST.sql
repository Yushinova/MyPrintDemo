insert into Users(Password,Login, Name, Surname, Phone)
values('110484tanya', 'sulin_art@mail.ru', 'Tanya', 'Yushinova', '8-905-45-46-999'),
('208574yuy','krecker@gmail.com','Vasya','Pupkin','8-900-526-33-11')
go
insert into Products(Name_product,Heigh, Width, Count_product, Cost_product)
values ('Business cards',50,90, 1000,1800),
('Business cards',50,90,2000,2800),
('Flyers A6',148, 105, 1000,1200),
('Flyers A6',148, 105, 2000,2100),
('Flyers A4',297, 210, 1000, 2400)
go
insert into Orders (Date_order, User_ID, Product_ID)
values(getdate(), 1, 1),
(getdate(), 1, 3),
(getdate(), 2, 2),
(getdate(), 2, 3)