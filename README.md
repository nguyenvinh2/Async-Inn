# Async-Inn

## Database buildout of Hotel Management using DOTNET Web Application.

This is a basic C# Web Application specifically written to create and manage a database structure of a Hotel.

V0.9 creates front end interfacing allowing users to manipulate the database via browser. 

V0.91 uses Dependency Injection so that the Controllers for Hotels, Rooms, and Amenities no longer directly interact with the database. Also some update CSS stylings.

This application uses DOTNET Framework to generate the webpages.

## Version

V0.8 - 10/25/2018 Buildout of Database
V0.9 - 10/27/2018 Added Navigation. Improved Front-End
V0.91 - 10/29/2019 Dependency Injection for Controllers.

## Requirements

Visual Studios 2017 or equivalent C# IDE

Entity Framework CORE

.NET Core 2.1 SDK

## Instructions

Clone this repo to local storage and open it up using Visual Studios 2017.

Open the AsyncInn.sln solution located in the Async-Inn folder.

Run IISExpress to host the webpages locally. The Web Browser should automatically open and redirect you to the Landing Page.

The Landing Page should have a table of the inititally crafted databases. Select the appropriate link to go to each data page.

Each Page gives the user to create new data or edit existing data where appropriate.

## Database Structure

There are Five Separate Data Tables located within the database. The Schema is displayed below:
![Console](Schema.PNG?raw=true "Output")


## Testing

N/A

## Result

V0.9
![Console](Capture.PNG?raw=true "Output")
![Console](Capture2.PNG?raw=true "Output")
![Console](Capture3.PNG?raw=true "Output")