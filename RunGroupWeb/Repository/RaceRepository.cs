using Microsoft.EntityFrameworkCore;
using RunGroupWeb.Data;
using RunGroupWeb.Interfaces;
using RunGroupWeb.Models;

namespace RunGroupWeb.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDataContext _applicationDataContext;

        public RaceRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }
        public bool Add(Race race)
        {
            _applicationDataContext.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _applicationDataContext.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAllRace()
        {
           return await _applicationDataContext.Races.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetByCity(string city)
        {
            return await _applicationDataContext.Races.Include(a=>a.Address).Where(c => c.Address.City.Contains(city)).ToArrayAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _applicationDataContext.Races.Include(a=>a.Address).FirstOrDefaultAsync(i =>i.Id == id);
        }

        public bool Save()
        {
           var saved = _applicationDataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race club)
        {
           _applicationDataContext.Races.Update(club);
            return Save();
        }
    }
}
