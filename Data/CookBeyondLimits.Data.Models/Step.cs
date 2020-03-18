namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Data.Common.Models;

    public class Step : BaseDeletableModel<int>
    {
        public Step()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        public int Number { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
