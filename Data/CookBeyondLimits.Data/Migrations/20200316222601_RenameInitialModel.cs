namespace CookBeyondLimits.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameInitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDietsAndHealth_DietsAndHealth_DietAndHealthId",
                table: "RecipeDietsAndHealth");

            migrationBuilder.DropTable(
                name: "DietsAndHealth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeDietsAndHealth",
                table: "RecipeDietsAndHealth");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDietsAndHealth_DietAndHealthId",
                table: "RecipeDietsAndHealth");

            migrationBuilder.DropColumn(
                name: "DietAndHealthId",
                table: "RecipeDietsAndHealth");

            migrationBuilder.AddColumn<int>(
                name: "HealthAndDietId",
                table: "RecipeDietsAndHealth",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeDietsAndHealth",
                table: "RecipeDietsAndHealth",
                columns: new[] { "RecipeId", "HealthAndDietId" });

            migrationBuilder.CreateTable(
                name: "HealthAndDiets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthAndDiets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDietsAndHealth_HealthAndDietId",
                table: "RecipeDietsAndHealth",
                column: "HealthAndDietId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthAndDiets_IsDeleted",
                table: "HealthAndDiets",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDietsAndHealth_HealthAndDiets_HealthAndDietId",
                table: "RecipeDietsAndHealth",
                column: "HealthAndDietId",
                principalTable: "HealthAndDiets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDietsAndHealth_HealthAndDiets_HealthAndDietId",
                table: "RecipeDietsAndHealth");

            migrationBuilder.DropTable(
                name: "HealthAndDiets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeDietsAndHealth",
                table: "RecipeDietsAndHealth");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDietsAndHealth_HealthAndDietId",
                table: "RecipeDietsAndHealth");

            migrationBuilder.DropColumn(
                name: "HealthAndDietId",
                table: "RecipeDietsAndHealth");

            migrationBuilder.AddColumn<int>(
                name: "DietAndHealthId",
                table: "RecipeDietsAndHealth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeDietsAndHealth",
                table: "RecipeDietsAndHealth",
                columns: new[] { "RecipeId", "DietAndHealthId" });

            migrationBuilder.CreateTable(
                name: "DietsAndHealth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietsAndHealth", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDietsAndHealth_DietAndHealthId",
                table: "RecipeDietsAndHealth",
                column: "DietAndHealthId");

            migrationBuilder.CreateIndex(
                name: "IX_DietsAndHealth_IsDeleted",
                table: "DietsAndHealth",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDietsAndHealth_DietsAndHealth_DietAndHealthId",
                table: "RecipeDietsAndHealth",
                column: "DietAndHealthId",
                principalTable: "DietsAndHealth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
