# Animal Shelter API

#### By _**Ryan Bass** (/probablynotryan)_ 

#### _Epicodus Independent Project Week 13: Building an API (with CRUD functionality)_

## Technologies Used

* C#
* ASP .NET Core
* MySql
* Entity / Linq / Razor
* Swagger / CORS

## Description

This RESTFUL API will allow a user to look at information about the pets at an animal shelter, as well as add, delete or edit animal info entries!

## Setup/Installation Requirements

* Download or clone this repository to your computer.
* Install [.NET 5](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net) if it is not installed already.
* In order to properly run the database, [install MySQL](https://dev.mysql.com/downloads/mysql/).
* In your terminal, type in ```dotnet tool install --global dotnet-ef``` to install dotnet ef.
* Navigate to the project folder of this downloaded repository and enter ```touch appsettings.json```. You can then edit that created file with a code editor of your choice and enter this on in it, followed by saving the file. (Be sure to replace PASSWORD with the password you provided during installation).: 
  ```csharp
  {
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=ryan_bass;uid=root;pwd=PASSWORD;"
    }
  } 
  ```
* (Guess what: we're still using terminal from inside AnimalShelterApi/) Enter ```dotnet build```
* After a successful build, enter ```dotnet ef database update``` (you guessed it: in terminal). This will create the database we use throughout this project, so make sure MySQL is running.
* Then enter ```dotnet run`` to start the API.
* In your preferred web browser, go to ```http://localhost:5000/swagger/``` to open the Swagger UI and see avaliable API endpoints and db schemas. Go wild!

## Known Bugs

* No reported bugs (yet)

## License

MIT
Copyright (c) _2022_ _Ryan Bass_