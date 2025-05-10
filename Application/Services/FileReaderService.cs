using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Abstract;

namespace Application.Services;

public class FileReaderService : IFileReaderService
{
    public T[] ReadCsv<T>(string fileName) where T: new()
    {
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
        using var reader = new StreamReader(fullPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        });

        var records = csv.GetRecords<T>().ToArray();
        return records;
    }
}