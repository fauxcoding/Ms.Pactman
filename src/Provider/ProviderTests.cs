using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Net.Http;
using System;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Provider
{
    public class ProviderTests
    {
        [Fact]
        public async Task GhostProvider_WhenProviderChanges_ExpectPactsAreStillHonoured()
        {
            var provider = "GhostProvider";

            // Define the providers message and structure
            //
            // Ideally this wouldn't be defined here. Instead we would invoke the logic that creates this message itself.
            // Otherwise we would have to constantly update this test.
            var @event = new GhostCreatedEvent
            {
                Id = Guid.NewGuid(),
                Name = "Clyde",
                Colour = "Orange",
            };

            var jsonObject = JObject.FromObject(@event);

            //
            // Call the broker and get all the pacts for this provider!
            //
            var client = new HttpClient();

            var request = await client.GetStringAsync($"http://localhost:5000/api/pacts/provider/{provider}");

            var pacts = JsonConvert.DeserializeObject<List<Pact>>(request);

            //
            // Go through each pact and verify our message conforms
            //
            foreach (var pact in pacts)
            {
                var isValid = jsonObject.IsValid(pact.Schema, out IList<string> messages);

                Assert.True(isValid, string.Join(" ", messages));
            }
        }
    }
}
