https://hub.docker.com/_/microsoft-mssql-server
https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash

Run container
> docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=<StrongPasswordHere>' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu

Start bash inside container
> docker exec -it the_container "bash"

Connect to the MSSQL server
> /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<StrongPasswordHere>'

Create database
> CREATE DATABASE SocialBoard

Verify database is created
> SELECT Name from sys.Databases

Execute previous commands
> GO

List all database tables
> use socialboard
> SELECT TABLE_NAME FROM socialboard.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'
> go

> select * from socialboardtweets
> go



List running containers
> docker ps -a


Start and stop container by name
> docker start the_container
> docker stop the_container


> dotnet ef migrations add InitialCreate
> dotnet ef database update