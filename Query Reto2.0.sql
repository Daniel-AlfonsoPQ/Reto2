create table libros(
   codigo int identity,
   titulo varchar(40),
   autor varchar(30),
   editorial varchar(20),
   precio decimal(5,2),
   cantidad smallint,
   primary key(codigo)
  );
  go
 
create proc pa_listar_libros
as
	select * from libros order by codigo;
go

create proc pa_buscar_libros
@titulo varchar(40)
as select * from libros 
where titulo like @titulo + '%'
go


create proc pa_mantenimiento_libros
@codigo int,
@titulo varchar(40),
@autor varchar(30),
@editorial varchar(20),
@precio decimal(5,2),
@cantidad smallint,
@accion varchar(50) output
as
	if(@accion='1')
		begin
		insert into libros (titulo,autor,editorial,precio,cantidad)
		values (@titulo,@autor,@editorial,@precio,@cantidad)
		set @accion= 'Se creo correctamente el libro ' + @titulo
		end
	else if (@accion='2')
		begin
		update libros set titulo=@titulo, autor=@autor,editorial=@editorial,precio=@precio,cantidad=@cantidad where convert(varchar,codigo)=convert(varchar,@codigo)
		set @accion= 'Se modifico correctamente el libro con código ' + convert(varchar,@codigo)
		END
	else if (@accion='3')
		begin
		delete from libros where codigo=@codigo
		set @accion= 'Se elimino correctamente el libro con código ' + convert(varchar,@codigo)
		end

if object_id('pa_buscar_libros') is not null
  drop procedure pa_buscar_libros;