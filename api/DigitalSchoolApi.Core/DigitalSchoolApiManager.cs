using DigitalSchoolApi.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace DigitalSchoolApi.Core
{
    public class DigitalSchoolApiManager(ILogger<DigitalSchoolApiManager> logger, IDigitalSchoolApiRepository repository) : IDigitalSchoolApiManager
    {
        private readonly ILogger<DigitalSchoolApiManager> _logger = logger;
        private readonly IDigitalSchoolApiRepository _repository = repository;

        public async Task<string> GetTestNameAsync()
        {
            return await _repository.GetTestNameAsync();
        }

        //public async Task<bool> SaveGameStateAsync(GameState gameState)
        //{
        //    return await _repository.SaveGameStateAsync(gameState);
        //}
    }
}



