using Microsoft.AspNetCore.Mvc;
using NugetPokemonACV.Repositories;
using NugetPokemonACV.Models;

namespace MvcCoreTestingNuget.Controllers
{
    public class PokemonController : Controller
    {
        private RepositoryPokemon repo;
        public PokemonController(RepositoryPokemon repo) 
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Pokemon> pokemons = this.repo.GetPokemons();
            return View(pokemons);
        }
        [HttpPost]
        public IActionResult Index(string? nombre, int? puntos)
        {
            if (nombre == null && puntos == null)
            {
                List<Pokemon> pokemons = this.repo.GetPokemons();
                return View(pokemons);
            }
            else if (nombre != null)
            {
                List<Pokemon> pokemons = this.repo.FindPokemonByName(nombre);
                return View(pokemons);
            }
            else if (puntos != null)
            {
                List<Pokemon> pokemons = this.repo.FindPokemonByPts(puntos.Value);
                return View(pokemons);
            }
            else
            {
                List<Pokemon> pokemons = this.repo.GetPokemons();
                return View(pokemons);
            }
        }
    }
}
