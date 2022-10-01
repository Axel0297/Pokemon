using Microsoft.AspNetCore.Mvc;
using Pokedex.Servicio_Api;
using System.Threading.Tasks;
namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IServicio_Api _servicioApi;


        public HomeController(IServicio_Api servicioApi)
        {
            _servicioApi = servicioApi;
        }

        
        public async Task<Pokemon> Pokemon(string nombre)
        {
            Pokemon pokemon = new Pokemon();

            ViewBag.accion = "Buscar Pokemon";
            if (nombre != null)
            {
                pokemon = await _servicioApi.Obtener(nombre);
            }
            return pokemon;
        }
    }
}