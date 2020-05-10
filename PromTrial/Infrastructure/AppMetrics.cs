using Prometheus;

namespace PromTrial.Infrastructure
{
    // AppMetrics have to be a singleton...
    // (and yes, I avoid static classes by default)
    public class AppMetrics
    {
        public Counter AllocatedStringsCounter { get; private set; }

        public AppMetrics()
        {
            AllocatedStringsCounter = Metrics.CreateCounter("app_allocated_strings_total", "Number of allocated strings.");
        }

    }
}