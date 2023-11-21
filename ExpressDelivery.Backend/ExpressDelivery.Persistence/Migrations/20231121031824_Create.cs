using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressDelivery.Persistence.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargoType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    IsActual = table.Column<bool>(type: "INTEGER", nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExecutorStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsActual = table.Column<bool>(type: "INTEGER", nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutorStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistoryMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsActual = table.Column<bool>(type: "INTEGER", nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistoryMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IsActual = table.Column<bool>(type: "INTEGER", nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Executor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    ExecutorStatus_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Executor_ExecutorStatus_ExecutorStatus_Id",
                        column: x => x.ExecutorStatus_Id,
                        principalTable: "ExecutorStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderStatus_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Executor_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    User_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ReceiptAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DeliveryAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    ReceiptTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Executor_Executor_Id",
                        column: x => x.Executor_Id,
                        principalTable: "Executor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatus_Id",
                        column: x => x.OrderStatus_Id,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Order_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CargoType_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargo_CargoType_CargoType_Id",
                        column: x => x.CargoType_Id,
                        principalTable: "CargoType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo_Order_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Order_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderHistoryMethod_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    TS = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderHistory_Order_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderHistory_OrderHistoryMethod_OrderHistoryMethod_Id",
                        column: x => x.OrderHistoryMethod_Id,
                        principalTable: "OrderHistoryMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CargoType_Id",
                table: "Cargo",
                column: "CargoType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_Id",
                table: "Cargo",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_Order_Id",
                table: "Cargo",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CargoType_Id",
                table: "CargoType",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Executor_ExecutorStatus_Id",
                table: "Executor",
                column: "ExecutorStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Executor_Id",
                table: "Executor",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExecutorStatus_Id",
                table: "ExecutorStatus",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Executor_Id",
                table: "Order",
                column: "Executor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Id",
                table: "Order",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatus_Id",
                table: "Order",
                column: "OrderStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_Id",
                table: "Order",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_orderHistory_Id",
                table: "orderHistory",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderHistory_Order_Id",
                table: "orderHistory",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_orderHistory_OrderHistoryMethod_Id",
                table: "orderHistory",
                column: "OrderHistoryMethod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistoryMethod_Id",
                table: "OrderHistoryMethod",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_Id",
                table: "OrderStatus",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "orderHistory");

            migrationBuilder.DropTable(
                name: "CargoType");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderHistoryMethod");

            migrationBuilder.DropTable(
                name: "Executor");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ExecutorStatus");
        }
    }
}
