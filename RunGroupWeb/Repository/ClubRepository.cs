using Microsoft.EntityFrameworkCore;
using RunGroupWeb.Data;
using RunGroupWeb.Interfaces;
using RunGroupWeb.Models;

namespace RunGroupWeb.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDataContext _applicationDataContext;

        public ClubRepository( ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }
        public bool Add(Club club)
        {
                _applicationDataContext.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _applicationDataContext.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _applicationDataContext.Clubs.ToListAsync();
        }

        public async Task<IEnumerable<Club>> GetByCity(string city)
        {
            return await _applicationDataContext.Clubs.Include(a=>a.Address).Where(c => c.Address.City.Contains(city)).ToListAsync(); 
        }
        public async Task<Club> GetByIdAsync(int id)
        {
            return await _applicationDataContext.Clubs.Include(i=>i.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = _applicationDataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            var deleted = _applicationDataContext.Clubs.Update(club);
            return Save();
        }
    }
}
