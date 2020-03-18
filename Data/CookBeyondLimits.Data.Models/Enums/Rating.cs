namespace CookBeyondLimits.Data.Models.Enums
{
    using System.ComponentModel;

    public enum Rating
    {
        Bad = 1,
        [Description("Not Great")]
        NotGreat = 2,
        Average = 3,
        Good = 4,
        Excellent = 5,
    }
}
