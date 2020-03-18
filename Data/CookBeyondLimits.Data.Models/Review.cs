namespace CookBeyondLimits.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CookBeyondLimits.Data.Common.Models;
    using CookBeyondLimits.Data.Models.Enums;

    public class Review : BaseDeletableModel<int>
    {
        public Review()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        public Rating Rating { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
