using System.Threading.Tasks;

namespace Pokedex.Servicio_Api
{
    public interface IServicio_Api
    {
        Task<Pokemon> Obtener(string Nombre);
    }
}
