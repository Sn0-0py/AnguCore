using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnguCore.Infrastructure.Data.Migrations
{
    public partial class AddHeroes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "AddedDate", "DeletedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Mr. Nice" },
                    { 2, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Narco" },
                    { 3, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Bombasto" },
                    { 4, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Celeritas" },
                    { 5, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Magneta" },
                    { 6, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "RubberMan" },
                    { 7, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Dynama" },
                    { 8, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Dr IQ" },
                    { 9, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Magma" },
                    { 10, new DateTime(2018, 10, 26, 8, 4, 49, 355, DateTimeKind.Utc), null, null, "Tornado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
