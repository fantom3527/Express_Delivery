using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressDelivery.Sqlite.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargo_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    is_actual = table.Column<bool>(type: "INTEGER", nullable: false),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cargo_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "executor_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    is_actual = table.Column<bool>(type: "INTEGER", nullable: false),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_executor_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_history_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    is_actual = table.Column<bool>(type: "INTEGER", nullable: false),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_history_method", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    is_actual = table.Column<bool>(type: "INTEGER", nullable: false),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "executor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    executor_status_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_executor", x => x.id);
                    table.ForeignKey(
                        name: "fk_executor_executor_status_executor_status_id",
                        column: x => x.executor_status_id,
                        principalTable: "executor_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    order_status_id = table.Column<int>(type: "INTEGER", nullable: false),
                    executor_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    receipt_address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    delivery_address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    receipt_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    delivery_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_executor_executor_id",
                        column: x => x.executor_id,
                        principalTable: "executor",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_order_order_status_order_status_id",
                        column: x => x.order_status_id,
                        principalTable: "order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    order_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    cargo_type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cargo", x => x.id);
                    table.ForeignKey(
                        name: "fk_cargo_cargo_type_cargo_type_id",
                        column: x => x.cargo_type_id,
                        principalTable: "cargo_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cargo_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_history",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    order_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    order_history_method_id = table.Column<int>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    ts = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_history_order_history_method_order_history_method_id",
                        column: x => x.order_history_method_id,
                        principalTable: "order_history_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_history_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cargo_cargo_type_id",
                table: "cargo",
                column: "cargo_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_cargo_id",
                table: "cargo",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_cargo_order_id",
                table: "cargo",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_cargo_type_id",
                table: "cargo_type",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_executor_executor_status_id",
                table: "executor",
                column: "executor_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_executor_id",
                table: "executor",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_executor_status_id",
                table: "executor_status",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_executor_id",
                table: "order",
                column: "executor_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_id",
                table: "order",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_order_status_id",
                table: "order",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_user_id",
                table: "order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_history_id",
                table: "order_history",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_history_order_history_method_id",
                table: "order_history",
                column: "order_history_method_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_history_order_id",
                table: "order_history",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_history_method_id",
                table: "order_history_method",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_status_id",
                table: "order_status",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_id",
                table: "user",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "order_history");

            migrationBuilder.DropTable(
                name: "cargo_type");

            migrationBuilder.DropTable(
                name: "order_history_method");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "executor");

            migrationBuilder.DropTable(
                name: "order_status");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "executor_status");
        }
    }
}
