using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWeb.Data;
using RunGroupWeb.Interfaces;
using RunGroupWeb.Models;

namespace RunGroupWeb.Controllers
{
	public class ClubController : Controller
	{
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        public async Task<IActionResult> Index()
		{
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
			return View(clubs);
		}
        public async Task< IActionResult> Details(int Id)
        {
            var club = await _clubRepository.GetByIdAsync(Id);
            return View(club);
        }
	}
}
