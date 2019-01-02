using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Order.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    TimeOfDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("7a9bb754-6026-4683-975f-f65bf3d25e96"), "Eggs", 1, 1 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("87dc3049-78cc-4f91-b1c0-ad1e1be4e7b2"), "Toast", 1, 2 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("3cb8ce5d-655c-4b54-a587-3a6f3e73b586"), "Coffee", 1, 3 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("3f70f7cf-7b84-47eb-8bcc-25bd9e42435c"), "Steak", 2, 1 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("65e37006-7644-4222-86bb-52743e498772"), "Potato", 2, 2 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("794d74ff-acbd-43a6-9476-0f702ba234fc"), "Wine", 2, 3 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("926f0a4d-d937-4f6f-ad6f-75b70716c912"), "Cake", 2, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");
        }
    }
}
