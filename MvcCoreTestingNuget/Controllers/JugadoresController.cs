using Microsoft.AspNetCore.Mvc;
using JugadoresNugetACV.Repositories;
using JugadoresNugetACV.Models;

namespace MvcCoreTestingNuget.Controllers
{
    public class JugadoresController : Controller
    {
        private RepositoryJugadores repo;

        public JugadoresController(RepositoryJugadores repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Jugador> players = this.repo.GetJugadores();
            return View(players);
        }
    }
}
