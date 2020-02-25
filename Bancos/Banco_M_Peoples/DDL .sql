Create Database M_Peoples
go 
Use M_Peoples
go
Create Table Funcionarios (
	Id			Int Primary Key Identity,
	Nome		VarChar(50),
	Sobrenome	VarChar(100)
);
