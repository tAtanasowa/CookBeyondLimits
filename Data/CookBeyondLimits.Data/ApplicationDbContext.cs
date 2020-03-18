namespace CookBeyondLimits.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using CookBeyondLimits.Data.Common.Models;
    using CookBeyondLimits.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Allergen> Allergens { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CookingStyle> CookingStyles { get; set; }

        public DbSet<Cuisine> Cuisines { get; set; }

        public DbSet<HealthAndDiet> HealthAndDiets { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<NutritionalFact> NutritionalFacts { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeAllergen> RecipeAllergens { get; set; }

        public DbSet<RecipeCookingStyle> RecipeCookingStyles { get; set; }

        public DbSet<RecipeHealthAndDiet> RecipeHealthAndDiets { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<RecipeTag> RecipeTags { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<TestedRecipe> TestedRecipes { get; set; }

        public DbSet<UserFavoriteRecipe> UserFavoriteRecipes { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void ConfigureUserIdentityRelations(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-many unidirectional relationship between Recipes and Allergens
            builder.Entity<RecipeAllergen>()
                .HasKey(ra => new { ra.RecipeId, ra.AllergenId });

            builder.Entity<RecipeAllergen>()
                .HasOne(ra => ra.Recipe)
                .WithMany(r => r.Allergens)
                .HasForeignKey(ra => ra.RecipeId);

            builder.Entity<RecipeAllergen>()
                .HasOne(ra => ra.Allergen)
                .WithMany(a => a.Recipes)
                .HasForeignKey(ra => ra.AllergenId);

            // Many-to-many unidirectional relationship between Recipes and CookingStyles
            builder.Entity<RecipeCookingStyle>()
                .HasKey(rcs => new { rcs.RecipeId, rcs.CookingStyleId });

            builder.Entity<RecipeCookingStyle>()
                .HasOne(rcs => rcs.Recipe)
                .WithMany(r => r.CookingStyles)
                .HasForeignKey(rcs => rcs.RecipeId);

            builder.Entity<RecipeCookingStyle>()
                .HasOne(rcs => rcs.CookingStyle)
                .WithMany(cs => cs.Recipes)
                .HasForeignKey(rcs => rcs.CookingStyleId);

            // Many-to-many unidirectional relationship between Recipes and HealthAndDiets
            builder.Entity<RecipeHealthAndDiet>()
                .HasKey(rhd => new { rhd.RecipeId, rhd.HealthAndDietId });

            builder.Entity<RecipeHealthAndDiet>()
                .HasOne(rhd => rhd.Recipe)
                .WithMany(r => r.HealthAndDiets)
                .HasForeignKey(rhd => rhd.RecipeId);

            builder.Entity<RecipeHealthAndDiet>()
                .HasOne(rhd => rhd.HealthAndDiet)
                .WithMany(hd => hd.Recipes)
                .HasForeignKey(rhd => rhd.HealthAndDietId);

            // Many-to-many unidirectional relationship between Recipes and Ingredients
            builder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            builder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(ri => ri.RecipeId);

            builder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.Recipes)
                .HasForeignKey(ri => ri.IngredientId);

            // Many-to-many unidirectional relationship between Recipes and Tags
            builder.Entity<RecipeTag>()
                .HasKey(rt => new { rt.RecipeId, rt.TagId });

            builder.Entity<RecipeTag>()
                .HasOne(rt => rt.Recipe)
                .WithMany(r => r.Tags)
                .HasForeignKey(rt => rt.RecipeId);

            builder.Entity<RecipeTag>()
                .HasOne(rt => rt.Tag)
                .WithMany(t => t.Recipes)
                .HasForeignKey(rt => rt.TagId);

            // Many-to-many relationship between Users and Recipes
            builder.Entity<Review>()
                .HasKey(r => new { r.UserId, r.RecipeId });

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            builder.Entity<Review>()
                .HasOne(r => r.Recipe)
                .WithMany(rec => rec.Reviews)
                .HasForeignKey(r => r.RecipeId);

            // Many-to-many relationship between Users and Recipes
            builder.Entity<TestedRecipe>()
                .HasKey(tr => new { tr.UserId, tr.RecipeId });

            builder.Entity<TestedRecipe>()
                .HasOne(tr => tr.User)
                .WithMany(u => u.TestedRecipes)
                .HasForeignKey(tr => tr.UserId);

            builder.Entity<TestedRecipe>()
                .HasOne(tr => tr.Recipe)
                .WithMany(r => r.CookedBy)
                .HasForeignKey(tr => tr.RecipeId);

            // Many-to-many relationship between Users and Recipes
            builder.Entity<UserFavoriteRecipe>()
                .HasKey(ufr => new { ufr.UserId, ufr.RecipeId });

            builder.Entity<UserFavoriteRecipe>()
                .HasOne(ufr => ufr.User)
                .WithMany(u => u.FavoriteRecipes)
                .HasForeignKey(ufr => ufr.UserId);

            builder.Entity<UserFavoriteRecipe>()
                .HasOne(ufr => ufr.Recipe)
                .WithMany(r => r.FavoredBy)
                .HasForeignKey(ufr => ufr.RecipeId);

            // One-to-one relationship between Recipes and NutritionalFacts
            builder.Entity<Recipe>()
                .HasOne(r => r.NutritionalFact)
                .WithOne(nf => nf.Recipe)
                .HasForeignKey<NutritionalFact>(nf => nf.RecipeId);

            // Unique constraints
            builder.Entity<Category>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        //private void ConfigureUserIdentityRelations(ModelBuilder builder)
        //     => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
