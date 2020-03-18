namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Data.Common.Models;

    public class CookingStyle : BaseDeletableModel<int>
    {
        public CookingStyle()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Recipes = new HashSet<RecipeCookingStyle>();
        }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public virtual ICollection<RecipeCookingStyle> Recipes { get; set; }
    }
}