Projekt zaliczeniowy z ASP .NET <br />
Techniki Internetowe, IiE 22/23 <br />
Projekt o strukturze Model-View-Controller, oparty na platformie .NET oraz EntityFramework. <br />
Autorzy: Łukasz Pyrek, Albert Pieniądz <br /> <br /> <br />


Aby stworzyć lokalną baze danych dla projektu w MSSQL(dla domyślnej ścieżki podanej poniżej) <br />
należy wpisać odpowiednio komendy do menadżera pakietów: <br /> 
Enable-Migrations <br />
add-migration First -Force <br />
update-database

connection string:
```
<connectionStrings>
		<add name ="SklepProjektConnectionString" connectionString="DataSource=(LocalDb)\MSSQLLocalDB;Initial
			 Catalog=SklepProjekt;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\SklepProjekt.mdf"
              providerName="System.Data.SqlClient" />
</connectionStrings>
```
