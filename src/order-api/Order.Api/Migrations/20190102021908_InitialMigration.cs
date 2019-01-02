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
                    TimeOfDay = table.Column<int>(nullable: false),
                    MultipleOrders = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Input = table.Column<string>(nullable: true),
                    Output = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "MultipleOrders", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("01dc2b47-158f-4d55-b84f-19fb1bce6468"), false, "Eggs", 1, 1 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "MultipleOrders", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("f29b1e83-b789-43a9-9f3b-020e1c5c8f4d"), false, "Toast", 1, 2 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "MultipleOrders", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("47734caf-4c93-4d50-bfb1-69ca830351cc"), true, "Coffee", 1, 3 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "MultipleOrders", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("2969d37e-a1d1-40fe-ba2e-4d7955335ddf"), false, "Steak", 2, 1 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "MultipleOrders", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("4d2a0198-5bde-4110-9e17-e4df59a5d79f"), true, "Potato", 2, 2 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "MultipleOrders", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("3962523f-7c1e-448a-95fc-c79438160e98"), false, "Wine", 2, 3 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "MultipleOrders", "Name", "TimeOfDay", "Type" },
                values: new object[] { new Guid("5276811a-1777-42bb-a16f-0584b9ba71d2"), false, "Cake", 2, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
