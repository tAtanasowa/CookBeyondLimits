namespace CookBeyondLimits.Data.Models.Enums
{
    using System.ComponentModel;

    public enum Measure
    {
        [Description("small")]
        Small = 1,

        [Description("medium")]
        Medium = 2,

        [Description("large")]
        Large = 3,

        [Description("kg")]
        Kilogram = 4,

        [Description("g")]
        Gram = 5,

        [Description("l")]
        Liter = 6,

        [Description("ml")]
        Milliliter = 7,

        [Description("tbsp")]
        Tablespoon = 8,

        [Description("tsp")]
        Teaspoon = 9,

        [Description("cup(s)")]
        Cup = 10,

        [Description("spray(s)")]
        Spray = 11,

        [Description("drop(s)")]
        Drop = 12,

        [Description("pcs")]
        Piece = 13,
    }
}
