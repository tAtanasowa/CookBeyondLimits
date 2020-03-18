namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Data.Common.Models;

    public class Allergen : BaseDeletableModel<int>
    {
        public Allergen()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Recipes = new HashSet<RecipeAllergen>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<RecipeAllergen> Recipes { get; set; }
    }
}
