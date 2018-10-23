using Newtonsoft.Json.Schema;

namespace Provider
{
    public class Pact
    {
        public string Provider { get; set; }

        public string Consumer { get; set; }

        public JSchema Schema { get; set; }
    }
}
