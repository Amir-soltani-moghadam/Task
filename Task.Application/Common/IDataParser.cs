namespace Task.Application.Common
{
    public interface IDataParser
    {
        Task<List<T>> ParseAsync<T>(string datatype, string data) where T : class, new();
    }
}
