using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using MyApp.API.Models;

namespace MyApp.API.Repositories
{
    public class TestRepository
    {
        private readonly IConfiguration _config;

        public TestRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<ShipmentDto>> GetShipmentDetails(
            int shipmentId,
            DateTime fromDt,
            DateTime toDt,
            string shipmentStatus,
            int userId)
        {
            using var connection = new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
            );

            var parameters = new DynamicParameters();
            parameters.Add("@ShipmentId", shipmentId);
            parameters.Add("@FromDt", fromDt);
            parameters.Add("@ToDt", toDt);
            parameters.Add("@ShipmentStatus", shipmentStatus);
            parameters.Add("@UserId", userId);

            var result = await connection.QueryAsync<ShipmentDto>(
                "uspGetShipmentDetail",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}