using MyApp.API.Models;
using MyApp.API.Repositories;

namespace MyApp.API.Services
{
    public class TestService
    {
        private readonly TestRepository _repo;

        public TestService(TestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ShipmentDto>> GetShipmentDetails(ShipmentFilterRequest request)
        {
            return await _repo.GetShipmentDetails(
                request.ShipmentId,
                request.FromDt,
                request.ToDt,
                request.ShipmentStatus ?? "",
                request.UserId
            );
        }





        
    }
}