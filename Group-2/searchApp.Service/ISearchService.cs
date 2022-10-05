using searchApp.Domain;

namespace searchApp.Service
{
    public interface ISearchService
    {
        Task<List<string>> GetSearch(string text);
    }
}
