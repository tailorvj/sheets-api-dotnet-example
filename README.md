# Read and write from/to a Google Sheets spreadsheet

* Fork this project
* Sign up for gitpod and open this project in a Gitpod workspace
* Login to Google Cloud Console
* Create a new project or use an existing one
* Add the Google Sheets API to your project
* Create a service account and make it an owner for Google Sheets
* Create and download credentials.json
* copy credentials.json to the project root
* Create a spreadsheet - https://sheets.new or use an existing one
* Manually write some data to the spreadsheet for reading function
* copy the spreadsheet id from the sheets doc URL
* In the gitpod environment terminal: export SPREADSHEET_ID="yourspreadsheetid"
* Variables to manually edit in Program.cs as needed: SheetName, NewData
* dotnet run - will log existing data to the console and append the new data
* Check the spreadsheet for new cells written from this script
* Modify the script as you wish

## About The Gitpod Development environment
This is a [.NET Core CLI](https://docs.microsoft.com/en-us/dotnet/core/introduction) template configured for ephemeral cloud development environments on [Gitpod](https://www.gitpod.io/).

## Next Steps

Click the button below to start a new development environment:

[![Open in Gitpod](https://gitpod.io/button/open-in-gitpod.svg)](https://gitpod.io/#https://github.com/gitpod-io/template-dotnet-core-cli-csharp)

## Get Started With Your Own Project

### A new project

Click the above "Open in Gitpod" button to start a new workspace. Once you're ready to push your first code changes, Gitpod will guide you to fork this project so you own it.

### An existing project

To get started with .NET Core CLI on Gitpod, add a [`.gitpod.yml`](./.gitpod.yml) file which contains the configuration to improve the developer experience on Gitpod. To learn more, please see the [Getting Started](https://www.gitpod.io/docs/getting-started) documentation.
