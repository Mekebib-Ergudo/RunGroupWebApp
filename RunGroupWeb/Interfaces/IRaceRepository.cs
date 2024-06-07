using RunGroupWeb.Models;

namespace RunGroupWeb.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAllRace();
        Task<Race> GetByIdAsync(int id);
        Task<IEnumerable<Race>>GetByCity(string city);
        bool Add(Race club);
        bool Update(Race club);
        bool Delete(Race club);
        bool Save();
    }
}
