using Dapper;
using FacturacionElectronica.Models;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FacturacionElectronica.Servicios
{
    public interface IRepositorioFacturacionElectronica
    {
        Task<IEnumerable<Estacionamientos>> BuscarEstacionamientos();
        Task<IEnumerable<Facturacion>> ObtenerPrefijoPorIdEstacionamiento(long idEstacionamiento);
    }
    public class RepositorioFacturacionElectronica : IRepositorioFacturacionElectronica
    {
        private readonly string connectionString;
        public RepositorioFacturacionElectronica(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public async Task<IEnumerable<Estacionamientos>> BuscarEstacionamientos()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Estacionamientos>("SELECT IdEstacionamiento,Nombre FROM T_Estacionamientos");
        }

        public async Task<IEnumerable<Facturacion>> ObtenerPrefijoPorIdEstacionamiento(long idEstacionamiento)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Facturacion>(@"SELECT IdFacturacion,Prefijo FROM T_Facturacion WHERE IdEstacionamiento=@IdEstacionamiento", new { idEstacionamiento });
        }
    }
}
