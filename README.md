# Shopify API Call into SQL Table Test

### Console API Call into SQL Table Exercise, 08.12.2020

By Tiffany Siu

## About

This is a simple, console application to test calling to Shopify API in C#/.NET and then using a stored procedure to store those values into a SQL table.  The table and stored procedure was created in SQL Server Managment Studio.  This uses the stored procedure `` and puts the results in the table ``.  

## Known Bugs

No known bugs at this time.

## Change Log
| Date		| Name			| Description					|
| ----------| ------------- | -----------------------------|
| 08.12.2020 |	Tiffany Siu |		Initialize project, add README, do simple single item call to API |
| 08.13.2020 |	Tiffany Siu |		Do simple call to get an array and print to console |
| 08.19.2020 |	Tiffany Siu	|		Add git, clear keys temporarily |

## Technologies Used

- C#
- .NET Framework
- [Shopify Admin API](https://shopify.dev/docs/admin-api)
- Markdown
- [RestSharp 105.2.3](https://restsharp.dev/)
- [NewtonSoft](https://www.newtonsoft.com/json)
- [Postman](https://www.postman.com/downloads/)
- SQL Server Management Studio


## User Stories
- As a Developer, I want to build a Console Application to access information from the Shopify API
- As a Developer, I need to traverse through all the fields provided to create a new SQL table.
- As a Developer, I will get JSON records with 50 results by default (250 results max) at a time and I will then need to parse the results in order to add them into the database.
- As a Developer, I need to add an API key to Web.config in order to access the LightSpeed eCom API.

## Instructions

1. Run this program with the `Program.cs` file as the main file
2. Console will show if inserting/updating the table was successful for each 
3. Can check if inserted correctly in SQL by running the query `SELECT * FROM {DATABASE TABLE HERE};` in SQL Server Management Studio

## API Call

### Syntax for making an API call to the Shopify Admin API

- General Syntax: `https://{API_KEY}:{PASSWORD}@{SITE}/admin/api/{VERSION}/{RESOURCE}.json{FILTERS}`




