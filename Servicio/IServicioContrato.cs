using System.Numerics;
using System.Threading.Tasks;

namespace Servicio
{
    public interface IServicioContrato
    {
        Task<BigInteger> SetearNumero();
        Task<BigInteger> ObtenerNumero();
    }
}