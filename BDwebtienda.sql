create database webtienda
go
create table Cliente
(
	Id int not null primary key,
	Nombre varchar(100) not null,
	Email varchar(100) not null,
	Direccion varchar(100) not null,
	Colonia varchar(100) not null,
	Ciudad varchar(100) not null,
	Telefono varchar not null,
	Contraseña varchar(50) not null,
	Activo varchar(2) not null
)
go
--listaclientes
create procedure spListaClientes
@IdNombre varchar(100)
as
begin
select * from Cliente where(convert(varchar(20),Id)+Nombre) 
like '%'+@IdNombre+'%' collate Latin1_General_CI_AI order by Id
end
go
--cargar cliente
create procedure spCargarCliente
@Id int 
as
begin
select * from Cliente where Id=@Id
end
go
--guardar cliente
create procedure spGuardarCliente
@Id int ,
@Nombre varchar(100),
@Email varchar(100),
@Direccion varchar(100),
@Colonia varchar(100),
@Ciudad varchar(100),
@Telefono int,
@Contraseña varchar(50),
@Activo varchar(2)
as
begin
if not exists(select Id from Cliente where Id=@Id)
begin
declare @MaxId int select @MaxId=isnull(max(Id+1),1) From Cliente
insert into Cliente(Id, Nombre, Email, Direccion, Colonia, Ciudad, TeleFono, Contraseña, Activo)
values(@MaxId,  @Nombre, @Email, @Direccion, @Colonia, @Ciudad, @TeleFono, @Contraseña, @Activo)
end
end
go
--editarcliente
create procedure spEditarCliente
@Id int ,
@Nombre varchar(100),
@Email varchar(100),
@Direccion varchar(100),
@Colonia varchar(100),
@Ciudad varchar(100),
@Telefono int,
@Contraseña varchar(50),
@Activo varchar(2)
as
begin
if exists(select * from Cliente where Id=@Id)
begin
update Cliente set Nombre=@Nombre, Email=@Email, Direccion=@Direccion, Colonia=@Colonia, Ciudad=@Ciudad, Telefono=@Telefono, Contraseña=@Contraseña, Activo=@Activo 
where Id=@Id
end
end
go
--borrarcliente
create procedure spBorrarCliente
@Id int
as
begin
delete from Cliente where Id=@Id
end
go
--pasar al siguiente cliente
create procedure spSiguienteCliente
as
begin
select isnull(max(Id+1),1) From Cliente
end