using System;
using Xunit;

namespace Provider
{
    public class GhostCreatedEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Colour { get; set; }
    }
}
