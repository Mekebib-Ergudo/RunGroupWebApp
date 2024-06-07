using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWeb.Data;
using RunGroupWeb.Interfaces;
using RunGroupWeb.Models;

namespace RunGroupWeb.Controllers
{
	public class RaceController : Controller
	{
 
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
		{
            IEnumerable<Race> races = await _raceRepository.GetAllRace();

            return View(races);
		}
        public async Task<IActionResult> Details(int Id)
        {
            Race race =  await _raceRepository.GetByIdAsync(Id);
            return View(race);
        }
    }
}
