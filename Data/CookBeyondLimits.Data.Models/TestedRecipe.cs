namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TestedRecipe
    {
        public TestedRecipe()
        {

            this.AddedOn = DateTime.UtcNow;
        }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
