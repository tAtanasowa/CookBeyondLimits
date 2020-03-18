namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Data.Common.Models;
    using CookBeyondLimits.Data.Models.Enums;

    public class Ingredient : BaseDeletableModel<int>
    {
        public Ingredient()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Recipes = new HashSet<RecipeIngredient>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Amount { get; set; }

        public Measure? Measure { get; set; }

        public virtual ICollection<RecipeIngredient> Recipes { get; set; }
    }
}
