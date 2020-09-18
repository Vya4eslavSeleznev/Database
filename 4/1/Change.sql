ALTER DATABASE Session
 MODIFY FILE (name = Session, maxsize = 100MB)
 GO
 EXEC SP_HELPDB Session
 Go
