using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
    static readonly string SpreadsheetId = Environment.GetEnvironmentVariable("SPREADSHEET_ID");
    //make sure you create a service account in Google Cloud Console and save the key to your project root
    static readonly string ServiceAccountPath = "credentials.json"; // replace with your service account file path
    static SheetsService service;

    //replace with your sheet name
    static readonly string SheetName = "Sheet1";
    //change data inside the object to your own strings
    static readonly List<object> NewData = new List<object> { "My", "Update", "Hello!" };

    static async Task Main(string[] args)
    {
        GoogleCredential credential;
        using (var stream = new FileStream(ServiceAccountPath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        }

        // Create Google Sheets API service.
        service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Google Sheets API .NET Quickstart",
        });

        // Read values from the Sheet.
        var readRange = $"{SheetName}"; // replace with your Sheet Name and Range
        var response = await service.Spreadsheets.Values.Get(SpreadsheetId, readRange).ExecuteAsync();
        Console.WriteLine("Reading values from the sheet:");
        foreach (var row in response.Values)
        {
            Console.WriteLine(string.Join(", ", row));
        }

        // Read values from the Sheet to determine the next available row.
        var readUpdateRange = $"{SheetName}!A:A"; // Read entire column A of the specified sheet
        var readResponse = await service.Spreadsheets.Values.Get(SpreadsheetId, readUpdateRange).ExecuteAsync();
        int nextRow = (readResponse.Values?.Count ?? 0) + 1; // Determine next available row

        // Write values to the Sheet starting at the next available row in column A.
        var writeRange = $"{SheetName}!A{nextRow}"; // Set the write range to start at the next available row
        var valueRange = new ValueRange() { Values = new List<IList<object>> { NewData } };
        var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, writeRange);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
        var update = await updateRequest.ExecuteAsync();

        Console.WriteLine($"Updated {update.UpdatedCells} cells.");
    }
}
