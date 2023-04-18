using API.Entities;

namespace API.Interfaces
{
    public interface IOptionService
    {
        Task<Option> GetOption(int id);
        Task<List<Option>> GetOptions();
        Task<bool> AddOption(Option Option);
        Task<bool> UpdateOption(Option Option);
        Task<bool> DeleteOption(int id);
    }
}
