namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Data.Common.Models;

    public class Cuisine : BaseDeletableModel<int>
    {
        public Cuisine()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Recipes = new HashSet<Recipe>();
        }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
