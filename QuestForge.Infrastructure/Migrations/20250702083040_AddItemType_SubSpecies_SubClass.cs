using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuestForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddItemType_SubSpecies_SubClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_OwnerCharacterId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Items",
                newName: "ItemTypeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerCharacterId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SpeciesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSpecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubSubClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSubClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSubClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Weapon" },
                    { 2, "Magic Weapon" },
                    { 3, "Armor" },
                    { 4, "Magic Armor" },
                    { 5, "Equipment" },
                    { 6, "Magic Equipment" },
                    { 7, "Tool" }
                });

            migrationBuilder.InsertData(
                table: "SubSpecies",
                columns: new[] { "Id", "Name", "SpeciesId" },
                values: new object[,]
                {
                    { 1, "Black", 2 },
                    { 2, "Blue", 2 },
                    { 3, "Brass", 2 },
                    { 4, "Bronze", 2 },
                    { 5, "Copper", 2 },
                    { 6, "Gold", 2 },
                    { 7, "Green", 2 },
                    { 8, "Red", 2 },
                    { 9, "Silver", 2 },
                    { 10, "White", 2 },
                    { 11, "Drow", 4 },
                    { 12, "High Elf", 4 },
                    { 13, "Wood Elf", 4 },
                    { 14, "Forest Gnome", 5 },
                    { 15, "Rock Gnome", 5 },
                    { 16, "Cloud Giant", 6 },
                    { 17, "Fire Giant", 6 },
                    { 18, "Frost Giant", 6 },
                    { 19, "Hill Giant", 6 },
                    { 20, "Stone Giant", 6 },
                    { 21, "Storm Giant", 6 },
                    { 22, "Cloud Giant", 6 },
                    { 23, "Abissal", 10 },
                    { 24, "Chthonic", 10 },
                    { 25, "Infernal", 10 }
                });

            migrationBuilder.InsertData(
                table: "SubSubClasses",
                columns: new[] { "Id", "ClassId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Path of the Berserker" },
                    { 2, 1, "Path of the Wild Heart" },
                    { 3, 1, "Path of the World Tree" },
                    { 4, 1, "Path of the Zealot" },
                    { 5, 2, "College of Dance" },
                    { 6, 2, "College of Glamour" },
                    { 7, 2, "College of Lore" },
                    { 8, 2, "College of Valor" },
                    { 9, 3, "Life Domain" },
                    { 10, 3, "Light Domain" },
                    { 11, 3, "Trickery Domain" },
                    { 12, 3, "War Domain" },
                    { 13, 4, "Circle of the Land" },
                    { 14, 4, "Circle of the Moon" },
                    { 15, 4, "Circle of the Sea" },
                    { 16, 4, "Circle of the Stars" },
                    { 17, 5, "Battle Master" },
                    { 18, 5, "Champion" },
                    { 19, 5, "Eldritch Knight" },
                    { 20, 5, "Psi Warrior" },
                    { 21, 6, "Warrior of Mercy" },
                    { 22, 6, "Warrior of Shadow" },
                    { 23, 6, "Warrior of the Elements" },
                    { 24, 6, "Warrior of the Open Hand" },
                    { 25, 7, "Oath of Devotion" },
                    { 26, 7, "Oath of Glory" },
                    { 27, 7, "Oath of Ancients" },
                    { 28, 7, "Oath of Vengeans" },
                    { 29, 8, "Beast Master" },
                    { 30, 8, "Fey Wanderer" },
                    { 31, 8, "Gloom Stalker" },
                    { 32, 8, "Hunter" },
                    { 33, 9, "Arcane Trickster" },
                    { 34, 9, "Assassin" },
                    { 35, 9, "Soulknife" },
                    { 36, 9, "Thief" },
                    { 37, 9, "Saboteur" },
                    { 38, 10, "Aberrant Sorcery" },
                    { 39, 10, "Clockwork Sorcery" },
                    { 40, 10, "Draconic Sorcery" },
                    { 41, 10, "Wild Magic Sorcery" },
                    { 42, 11, "Archfey Patron" },
                    { 43, 11, "Celestial Patron" },
                    { 44, 11, "Fiend Patron" },
                    { 45, 11, "Great Old One Patron" },
                    { 46, 11, "Hexblade" },
                    { 47, 12, "Abjurer" },
                    { 48, 12, "Diviner" },
                    { 49, 12, "Evoker" },
                    { 50, 12, "Illusionist" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSpecies_SpeciesId",
                table: "SubSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSubClasses_ClassId",
                table: "SubSubClasses",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_OwnerCharacterId",
                table: "Items",
                column: "OwnerCharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_OwnerCharacterId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "SubSpecies");

            migrationBuilder.DropTable(
                name: "SubSubClasses");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ItemTypeId",
                table: "Items",
                newName: "Type");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerCharacterId",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_OwnerCharacterId",
                table: "Items",
                column: "OwnerCharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
