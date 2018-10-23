using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Schema;

namespace Broker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PactsController : ControllerBase
    {
        //
        // Represents an in-memory collection of pact contracts. Ideally this would be persisted to a data store.
        //
        private static ConcurrentBag<Pact> pacts = new ConcurrentBag<Pact>();

        //
        // Summary:
        //     Gets the pact contracts for the given provider
        //     /api/pacts/provider/ExampleProvider
        //      
        [Route("provider/{provider}")]
        public ActionResult Get(string provider)
        {
            if (string.IsNullOrEmpty(provider))
            {
                return BadRequest();
            }

            var providerPacts = pacts.Where(x => x.Provider == provider).ToList();

            return Ok(providerPacts);
        }

        //
        // Summary:
        //     Creates a pact for the given consumer against the given provider
        //     /api/pacts/provider/ExampleProvider
        //      
        [HttpPost]
        [Route("consumer/{consumer}/provider/{provider}")]
        public ActionResult Post(string consumer, string provider, JSchema schema)
        {
            if (string.IsNullOrEmpty(consumer) || string.IsNullOrEmpty(provider) || schema.Valid == false)
            {
                return BadRequest();
            }

            pacts.Add(new Pact
            {
                Consumer = consumer,
                Provider = provider,
                Schema = schema
            });

            return Ok();
        }
    }
}
