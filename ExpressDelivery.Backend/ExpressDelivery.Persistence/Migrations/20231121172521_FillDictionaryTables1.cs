using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressDelivery.Persistence.Migrations
{
    public partial class FillDictionaryTables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "Cargo",
                            columns: new[] { "Id", "CargoTypeId", "Name", "Description" },
                            values: new object[,]
                            {
                                { Guid.NewGuid(), 1, "CargoName1", "Description1" },
                                { Guid.NewGuid(), 2, "CargoName2", "Description2" },
                                { Guid.NewGuid(), 3, "CargoName3", "Description3" }
                            });


            migrationBuilder.InsertData(
                            table: "User",
                            columns: new[] { "Id", "Name", "Description" },
                            values: new object[,]
                            {
                                { Guid.NewGuid(), "John Doe", "Description 1" },
                                { Guid.NewGuid(), "Jane Smith", "Description 2" },
                                { Guid.NewGuid(), "Alice Johnson", "Description 3" }
                            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
