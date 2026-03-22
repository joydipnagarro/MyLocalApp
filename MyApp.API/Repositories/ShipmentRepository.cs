using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using MyApp.API.Models;

namespace MyApp.API.Repositories
{
    public class ShipmentRepository
    {
        private readonly IConfiguration _config;

        public ShipmentRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<ShipmentDto>> GetShipmentDetails(
            ShipmentFilterRequest request)
        {
            using var connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            var parameters = new DynamicParameters();
            parameters.Add("@ShipmentId", request.ShipmentId);
            parameters.Add("@FromDt", request.FromDt);
            parameters.Add("@ToDt", request.ToDt);
            parameters.Add("@ShipmentStatus", request.ShipmentStatus);
            parameters.Add("@UserId", request.UserId);

            var result = await connection.QueryAsync<ShipmentDto>(
                "uspGetShipmentDetail",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}