namespace Domain.Abstract;

/// <summary>
/// Interface for file reader service
/// </summary>
public interface IFileReaderService
{
    /// <summary>
    /// Read csv file and map it to the specified type
    /// </summary>
    /// <param name="fileName">Name of the csv file</param>
    /// <typeparam name="T">Type to map the csv file to</typeparam>
    /// <returns>Array of mapped objects</returns>
    T[] ReadCsv<T>(string fileName) where T : new();
}