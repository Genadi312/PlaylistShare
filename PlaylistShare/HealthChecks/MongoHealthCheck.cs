using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlaylistShare.Models.Configs;

namespace PlaylistShare.HealthChecks
{
    public class MongoHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<MongoDbConfig> _mongoConfig;
        public MongoHealthCheck(IConfiguration configuration, IOptionsMonitor<MongoDbConfig> mongoConfig)
        {
            _configuration = configuration;
            _mongoConfig = mongoConfig;
        }

        async Task<HealthCheckResult> IHealthCheck.CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
        {
            try
            {
                var client = new MongoClient(_mongoConfig.CurrentValue.ConnectionString);
            }

            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Connection with MongoDb is unhealthy");
            }

            return HealthCheckResult.Healthy("Connection with MongoDb is okay");
        }
    }
}
