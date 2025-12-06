create database movie 
go

use movie

create table users
(
	id int primary key identity(1,1),
	username varchar(MAX) NULL,
	password varchar(MAX) null,
	role varchar(MAX) null,
	status varchar(MAX) null,
	date_reg DATE null,
)

select * from users

INSERT INTO users (username, password, role, status, date_reg) VALUES
	('admin', 'admin123', 'Admin', 'Active', '2025-11-30')