namespace Domain.Abstract;

public interface IFileReaderService
{
    T[] ReadCsv<T>(string fileName) where T : new();
}