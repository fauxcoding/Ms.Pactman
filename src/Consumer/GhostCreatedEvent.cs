using System;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace Consumer
{
    public class GhostCreatedEvent
    {
        [Required]
        [RegularExpression("(^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$)")]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(GhostColour))]
        public string Colour { get; set; }
    }

    public enum GhostColour
    {
        Pink,
        Blue,
        Red,
        Orange
    }
}
