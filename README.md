# Async-Inn

## Database buildout of Hotel Management using DOTNET Web Application.

This is a basic C# Web Application specifically written to create and manage a database structure of a Hotel.
It utilizes a SQL Relational Database to store all entries. 

V0.9 creates front end interfacing allowing users to manipulate the database via browser. 

V0.91 uses Dependency Injection so that the Controllers for Hotels, Rooms, and Amenities no longer directly interact with the database. Also some update CSS stylings.

V1.0 is deployed using Azure Web Services. It can be found at: http://asynninn.azurewebsites.net/


This application uses DOTNET Framework to generate the webpages.

## Version

V0.8 - 10/25/2018 Buildout of Database
V0.9 - 10/27/2018 Added Navigation. Improved Front-End
V0.91 - 10/29/2018 Dependency Injection for Controllers.
V1.0 - 11/4/2018 Basic Completion and Web Deployed.

## Requirements

Visual Studios 2017 or equivalent C# IDE

Entity Framework CORE

.NET Core 2.1 SDK

Microsoft SQL Database

Azure or other Web Service for hosting

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

The following tests were done in XUnit

1. Getters/Setters on all Models

2. Standard CRUD operations on all tables

## Result

V0.9
![Console](Capture.PNG?raw=true "Output")
![Console](Capture2.PNG?raw=true "Output")
![Console](Capture3.PNG?raw=true "Output")