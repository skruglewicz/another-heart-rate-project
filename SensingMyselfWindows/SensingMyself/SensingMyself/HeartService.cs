using Microsoft.Azure;
using Microsoft.Azure.TimeSeriesInsights;
using Microsoft.Azure.TimeSeriesInsights.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace SensingMyself
{
    public class HeartService
    {
        private static TimeSeriesInsightsClient client;
        private static string[] timeSeriesId;

        static HeartService()
        {
            client = GetTimeSeriesInsightsClient();
            timeSeriesId = new string[] { ConfigurationManager.AppSettings["TimeSeriesId"] };
        }

        public List<Reading> GetToday()
        {
            return GetReadingsBetween(DateTime.Today, DateTime.Today.AddDays(1));
        }

        public DateTime? GetLastReadingDateTime()
        {
            var readings = GetReadingsBetween(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1));

            return readings.Max(r => r.TimeStamp);
        }
        private List<Reading> GetReadingsBetween(DateTime from, DateTime to)
        {
            var readings = new List<Reading>();
            DateTimeRange SearchToday = new DateTimeRange(from.ToUniversalTime(), to.ToUniversalTime());

            string continuationToken;
            do
            {
                QueryResultPage queryResponse = client.ExecuteQueryPagedAsync(
                    new QueryRequest(
                        getEvents: new GetEvents(timeSeriesId: timeSeriesId, searchSpan: SearchToday, filter: null))).Result;

                readings.AddRange(ParseReadings(queryResponse));

                continuationToken = queryResponse.ContinuationToken;
            }
            while (continuationToken != null);

            return readings;

        }

        private List<Reading> ParseReadings(QueryResultPage queryResultPage)
        {
            var readings = new List<Reading>();

            if (queryResultPage.Properties != null && queryResultPage.Timestamps != null)
            {
                Console.Write("timestamp,");
                Console.WriteLine(string.Join(",", queryResultPage.Properties.Select(v => v.Name)));
                int i = 0;
                var heartRates = queryResultPage.Properties.Where(p => p.Name == "heart_rate").First();
                var o2s = queryResultPage.Properties.Where(p => p.Name == "o2").First();

                foreach (DateTime? bodyTimestamp in queryResultPage.Timestamps)
                {
                    Reading reading = new Reading();
                    reading.TimeStamp = bodyTimestamp;
                    reading.HeartRate = int.Parse(heartRates.Values[i].ToString());
                    reading.SpO2 = (double)o2s.Values[i];
                    readings.Add(reading);
                    i++;
                }
                Console.WriteLine();
            }
            return readings;


        }
        private static TimeSeriesInsightsClient GetTimeSeriesInsightsClient()
        {
            string tenant = ConfigurationManager.AppSettings["AadTenant"];
            string clientId = ConfigurationManager.AppSettings["ClientId"];
            string clientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            string environmentFqdn = ConfigurationManager.AppSettings["TimeSeriesEnvironment"];

            AuthenticationContext context = new AuthenticationContext($"https://login.windows.net/{tenant}", TokenCache.DefaultShared);
            AuthenticationResult authenticationResult = context.AcquireTokenAsync("https://api.timeseries.azure.com/", new ClientCredential(clientId, clientSecret)).Result;

            TokenCloudCredentials tokenCloudCredentials = new TokenCloudCredentials(authenticationResult.AccessToken);
            ServiceClientCredentials serviceClientCredentials = new TokenCredentials(tokenCloudCredentials.Token);

            TimeSeriesInsightsClient timeSeriesInsightsClient = new TimeSeriesInsightsClient(credentials: serviceClientCredentials)
            {
                EnvironmentFqdn = environmentFqdn
            };
            return timeSeriesInsightsClient;
        }
    }
}
