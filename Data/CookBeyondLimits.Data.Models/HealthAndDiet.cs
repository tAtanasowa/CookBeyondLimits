namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Data.Common.Models;

    public class HealthAndDiet : BaseDeletableModel<int>
    {
        public HealthAndDiet()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Recipes = new HashSet<RecipeHealthAndDiet>();
        }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public virtual ICollection<RecipeHealthAndDiet> Recipes { get; set; }
    }
}
