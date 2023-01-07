# Mechanic Factory

#### By Bodie Wood

## Technologies Used

- C#
- .NET 6
- ASP.NET Core MVC
- Entity
- MySQL
- HTML
- CSS

## Description

This website gives employer the ability to see a view of all company mechanics and machines on one splash screen. Allows employer to view details of a machine to see all mechanics for each machine, view all details of a mechanic for each machine. Employers can edit machines and mechanics as needed.

## Setup/Installation Requirements

* _Open up your terminal and navigate to the desired landing folder_
* _In terminal Run:  ```git clone https://github.com/bodwood/Mechanic-Factory.git```_
* _In terminal enter ```code .``` to open files in Visual Studio Code_
* _In VS Code open a new terminal_
  1. _In VS Code termainl run:  ```dotnet add package Microsoft.EntityFrameworkCore -v 6.0.0```_
  2. _In VS Code terminal run:  ```dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.0```_
  3. _Run:  ```dotnet restore```_
  **If you run into errors try running ```dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0```**

* _Create a new file called ```appsettings.json``` within the Factory directory_
  *  In VS Code terminal: 
      - Run:  ```cd Factory```
      - Run:  ```touch appsettings.json```
* _Enter the following into the file:_
```json
    {
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DATABASE-HERE];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];"
      }
  }
```
* _Make sure to set uid and pwd_
* _Run: ```dotnet run``` in VS Code termainl to start the program_

## Known Bugs

* _No known bugs_

## License

_[MIT](https://en.wikipedia.org/wiki/MIT_License)_

Copyright (c) _2022_ Bodie Wood