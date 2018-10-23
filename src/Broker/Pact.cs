using Newtonsoft.Json.Schema;

namespace Broker.Controllers
{
    public class Pact
    {
        public string Provider { get; set; }

        public string Consumer { get; set; }

        public JSchema Schema { get; set; }
    }
}
