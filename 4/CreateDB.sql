USE master
Go
CREATE DATABASE Session ON
(
	Name= Session, 
	FileName='C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Session.mdf'
) 
LOG ON 
(
	Name= Session_log, 
	FileName='C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Session_log.ldf'
) 
Go
