using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBeyondLimits.Data.Migrations
{
    public partial class RenameMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDietsAndHealth_HealthAndDiets_HealthAndDietId",
                table: "RecipeDietsAndHealth");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDietsAndHealth_Recipes_RecipeId",
                table: "RecipeDietsAndHealth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeDietsAndHealth",
                table: "RecipeDietsAndHealth");

            migrationBuilder.RenameTable(
                name: "RecipeDietsAndHealth",
                newName: "RecipeHealthAndDiets");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeDietsAndHealth_HealthAndDietId",
                table: "RecipeHealthAndDiets",
                newName: "IX_RecipeHealthAndDiets_HealthAndDietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeHealthAndDiets",
                table: "RecipeHealthAndDiets",
                columns: new[] { "RecipeId", "HealthAndDietId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeHealthAndDiets_HealthAndDiets_HealthAndDietId",
                table: "RecipeHealthAndDiets",
                column: "HealthAndDietId",
                principalTable: "HealthAndDiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeHealthAndDiets_Recipes_RecipeId",
                table: "RecipeHealthAndDiets",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeHealthAndDiets_HealthAndDiets_HealthAndDietId",
                table: "RecipeHealthAndDiets");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeHealthAndDiets_Recipes_RecipeId",
                table: "RecipeHealthAndDiets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeHealthAndDiets",
                table: "RecipeHealthAndDiets");

            migrationBuilder.RenameTable(
                name: "RecipeHealthAndDiets",
                newName: "RecipeDietsAndHealth");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeHealthAndDiets_HealthAndDietId",
                table: "RecipeDietsAndHealth",
                newName: "IX_RecipeDietsAndHealth_HealthAndDietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeDietsAndHealth",
                table: "RecipeDietsAndHealth",
                columns: new[] { "RecipeId", "HealthAndDietId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDietsAndHealth_HealthAndDiets_HealthAndDietId",
                table: "RecipeDietsAndHealth",
                column: "HealthAndDietId",
                principalTable: "HealthAndDiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDietsAndHealth_Recipes_RecipeId",
                table: "RecipeDietsAndHealth",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
