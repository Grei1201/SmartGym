select * from SALES.Customer


select SC.CustomerID, 
SC.PersonID, SC.StoreID, SC.TerritoryID,
SST.Name
from SALES.Customer SC
INNER JOIN Sales.SalesTerritory SST
on SC.TerritoryID = SST.TerritoryID
Where SST.Name like + '%'+ 'Ca'+'%'
and SC.PersonID is not null
and SC.StoreID is not null


--Seeccion para declaracion de paranametros 

create procedure ListadoDePersonal_sp
as 
select FirstNAme Nombre, 
LastName Apellido, 
Title Puesto
from Person.Person
---fin del procedimiento almacenado 

--ejecucion de un procedimiento almacenado
execute ListadoDePersonal_sp

--Eliminar un porcedimiento almacenado 
drop procedure ListadoDePersonal_sp


--creacion de un procedmiento almacenado 
create or alter procedure ListadoDePersonal_sp
as 
select FirstNAme Nombre, 
LastName Apellido, 
Title Titulo
from Person.Person
where Title is not null

-- verificar la logica de un procedimiento almacenado 
sp_helptext ListadoDePersonal_sp

--- creacion de un store utiolizxando parametros
create proc ListDistProduc_sp


DECLARE @RC int
DECLARE @Precio1 money
DECLARE @Precio2 money

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[ListDistProd_sp] 
   @Precio1
  ,@Precio2
GO

s