using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuestForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSpeciesAndClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Species",
                table: "Characters",
                newName: "SpeciesId");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Characters",
                newName: "ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Campaigns",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Barbarian" },
                    { 2, "Bard" },
                    { 3, "Cleric" },
                    { 4, "Druid" },
                    { 5, "Fighter" },
                    { 6, "Monk" },
                    { 7, "Paladin" },
                    { 8, "Ranger" },
                    { 9, "Rogue" },
                    { 10, "Sorcerer" },
                    { 11, "Warlock" },
                    { 12, "Wizard" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Aasimar" },
                    { 2, "Dragonborn" },
                    { 3, "Dwarf" },
                    { 4, "Elf" },
                    { 5, "Gnome" },
                    { 6, "Goliath" },
                    { 7, "Halfling" },
                    { 8, "Human" },
                    { 9, "Orc" },
                    { 10, "Tiefling" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SpeciesId",
                table: "Characters",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Species_SpeciesId",
                table: "Characters",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Classes_ClassId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Species_SpeciesId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ClassId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SpeciesId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "Characters",
                newName: "Species");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Characters",
                newName: "Class");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Campaigns",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
