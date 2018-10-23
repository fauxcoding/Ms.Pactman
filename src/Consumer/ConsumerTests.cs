using System;
using Xunit;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace Consumer
{
    public class ConsumerTests
    {
        [Fact]
        public async Task Test1()
        {
            var consumerName = "GameConsumer";
            var providerName = "GhostProvider";

            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(GhostCreatedEvent));

            var serialized = schema.ToString();

            var client = new HttpClient();

            await client.PostAsync($"http://localhost:5000/api/pacts/consumer/{consumerName}/provider/{providerName}", new StringContent(serialized, Encoding.UTF8, "application/json"));
        }
    }
}
