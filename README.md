Insecure Website
================

This example site shows vulnerabilities in SQL Injection and XSS Injection.

How to Use
----------

1. Install .NET Core 3.0 or newer from https://dotnet.microsoft.com/download

2. Install SQL Server from https://www.microsoft.com/en-us/sql-server/sql-server-downloads (developer edition and express edition are free) or from https://hub.docker.com/_/microsoft-mssql-server

3. Clone or download this repository

4. Use the files in the `sql` directory to create a database in SQL Server

5. Set the connection string in `app/appsettings.json` (see https://www.connectionstrings.com/sql-server/)

6. Run `InsecureWebsite.sln` from Visual Studio or `dotnet run` from the command line

Legal
-----

Copyright @ 2019 Richardson & Sons, LLC

License: MIT
