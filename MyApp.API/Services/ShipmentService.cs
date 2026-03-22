using MyApp.API.Models;
using MyApp.API.Repositories;

namespace MyApp.API.Services
{
    public class ShipmentService
    {
        private readonly ShipmentRepository _repo;

        public ShipmentService(ShipmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ShipmentDto>> GetShipmentDetails(
            ShipmentFilterRequest request)
        {
            try
            {
                // ✅ Validation
                if (request == null)
                    throw new Exception("Request cannot be null");

                if (request.UserId <= 0)
                    throw new Exception("Invalid user");

                // ✅ Call repository
                var result = await _repo.GetShipmentDetails(request);

                return result;
            }
            catch (Exception)
            {
                // ❗ Let middleware handle it
                throw;
            }
        }
    }
}