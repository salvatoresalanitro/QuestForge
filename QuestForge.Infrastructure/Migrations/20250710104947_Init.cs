using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuestForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubClass_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    HitPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    ArmorClass = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    CampaignId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Characters_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
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
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CampaignId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Item_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Item_ItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Class",
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
                table: "ItemType",
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

            migrationBuilder.InsertData(
                table: "SubClass",
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
                    { 24, 6, "Warrior of of the Open Hand" },
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
                    { 46, 11, "Hexblade Patron" },
                    { 47, 12, "Abjurer" },
                    { 48, 12, "Diviner" },
                    { 49, 12, "Evoker" },
                    { 50, 12, "Illusionist" }
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
                    { 22, "Abissal", 10 },
                    { 23, "Chtonic", 10 },
                    { 24, "Infernal", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CampaignId",
                table: "Characters",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SpeciesId",
                table: "Characters",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CampaignId",
                table: "Item",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CharacterId",
                table: "Item",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_TypeId",
                table: "Item",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubClass_ClassId",
                table: "SubClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSpecies_SpeciesId",
                table: "SubSpecies",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "SubClass");

            migrationBuilder.DropTable(
                name: "SubSpecies");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
