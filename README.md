# Entity Framework  mit GenericRepository und zwei Datenbank Provider


## Entity Framework


```console
dotnet tool install --global dotnet-ef

dotnet tool update --global dotnet-ef

cd .\EF_GenericRepository_2Database_repository\   


dotnet ef migrations add InitialCreate --startup-project ../EF_GenericRepository_2Database/ --project ../EF_GenericRepository_2Database.Postgres -- --DatabaseProvider Postgres


dotnet ef migrations add InitialCreate --startup-project ../EF_GenericRepository_2Database/ --project ../EF_GenericRepository_2Database.MSSql -- --DatabaseProvider MSSql

```


