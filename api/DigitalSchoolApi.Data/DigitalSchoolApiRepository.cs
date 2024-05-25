using Dapper;
using DigitalSchoolApi.Core.Options;
using DigitalSchoolApi.Core.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace DigitalSchoolApi.Data
{
    public class DigitalSchoolApiRepository : IDigitalSchoolApiRepository
    {
        private readonly ILogger<DigitalSchoolApiRepository> _logger;
        private readonly IOptions<DigitalSchoolApiOptions> _options;

        public DigitalSchoolApiRepository(ILogger<DigitalSchoolApiRepository> logger, IOptions<DigitalSchoolApiOptions> options)
        {
            _logger = logger;
            _options = options;
        }

        public async Task<string> GetTestNameAsync()
        {
            _logger.LogDebug("Entered {class} {method}", nameof(DigitalSchoolApiRepository), nameof(GetTestNameAsync));
            try
            {
                using var connection = new NpgsqlConnection(_options.Value.ConnectionString);
                var result = await connection.QuerySingleAsync<string>("SELECT name FROM test LIMIT 1", new { }, commandType: CommandType.Text);
                _logger.LogDebug("Return from {class} {method}, result: {result}", nameof(DigitalSchoolApiRepository), nameof(GetTestNameAsync), result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{class} {method}: Error getting test name", nameof(DigitalSchoolApiRepository), nameof(GetTestNameAsync));
                return "";
            }
        }

        //public async Task<bool> SaveGameStateAsync(Core.Models.GameState gameState)
        //{
        //    _logger.LogDebug("Entered {class} {method}", nameof(DigitalSchoolApiRepository), nameof(SaveGameStateAsync));
        //    try
        //    {
        //        using (var connection = new SqlConnection(_options.Value.ConnectionString))
        //        {
        //            var affectedRows = await connection.ExecuteAsync(_options.Value.SaveGameStateStoredProcedureName, new { GameID = gameState.GameId, gameState.History, gameState.TurnNumber }, commandType: CommandType.StoredProcedure);
        //            if (affectedRows == 1)
        //            {
        //                _logger.LogDebug("Returning from {class} {method} {affectedRows}", nameof(DigitalSchoolApiRepository), nameof(SaveGameStateAsync), affectedRows);
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error saving game state {gameState}", gameState);
        //        return false;
        //    }
        //}

    }
}
