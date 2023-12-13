using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressDelivery.Sqlite.Migrations
{
    public partial class FillTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "name", "description" },
                values: new object[,]
                {
                    { Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"), "Костя Шипачев", "Программист" },
                    { Guid.Parse("7EEF1949-580D-4F67-B754-EC74CA91D836"), "Юлия Когнитова", "Швея" },
                    { Guid.Parse("7D35C407-7930-4BC8-A1DD-D8610155472A"), "Дима Усатый", "Тракторист" }
                });

            migrationBuilder.InsertData(
                table: "cargo",
                columns: new[] { "id", "cargo_type_id", "name", "description" },
                values: new object[,]
                {
                    { Guid.Parse("66945C5A-7506-4D3D-BE01-49867C4E0A04"), 1, "Машина", "Белая машина" },
                    { Guid.Parse("07E0E4F3-6DCB-4F50-851C-D24731849451"), 2, "Компьютер", "Игровой компьютер" },
                    { Guid.Parse("02A92B52-5F65-46D6-BB31-A0CE8D781396"), 3, "Сахар", "Белый сахар" }
                });

            migrationBuilder.InsertData(
                table: "executor",
                columns: new[] { "id", "name", "description", "executor_status_id" },
                values: new object[,]
                {
                   { Guid.Parse("A8D8532E-9DAA-4451-BE64-CC760E6A815C"), "Анна", "Опытный координатор по доставке грузов", 1 },
                   { Guid.Parse("A4FC44C7-A880-451C-938C-78D5515201ED"), "Антон", "Быстрая и эффективная доставка", 2 },
                   { Guid.Parse("A56E0344-8120-4543-91D0-0726CA1DF416"), "Денис", "Опытный и надежный", 1 },
                   { Guid.Parse("A536A4B2-40AF-4F46-9925-177E70AFDF87"), "Роман", "Известен своей скоростью и надежностью", 3 }
                });

            migrationBuilder.InsertData(
                table: "order",
                columns: new[] { "id", "user_id", "order_status_id", "executor_id", "receipt_address", "delivery_address",
                                 "name", "description", "receipt_time", "delivery_time" },
                values: new object[,]
                {
                    { Guid.Parse("A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568"), Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"), 3,
                     Guid.Parse("A4FC44C7-A880-451C-938C-78D5515201ED"), "Новосибирск, улица Лениа 2", "Орск, улица Карпова 10", "Доставка компьютера", "Внимание! Доставка ценных грузов",
                     "2023-10-10 00:00:00", "2023-10-23 00:00:00" },

                    { Guid.Parse("8CC409BF-33EA-4FD5-8952-28EC247D4C4B"), Guid.Parse("7EEF1949-580D-4F67-B754-EC74CA91D836"), 1,
                     null, "Владивосток, улица Беринга 1", "Кемерово, улица Беглово 9",
                     "Order", "No cargo has been added to the", "2023-11-01 00:00:00", "2023-11-03 00:00:00" },
                });

            migrationBuilder.UpdateData(
                table: "cargo",
                keyColumn: "id",
                keyValue: Guid.Parse("07E0E4F3-6DCB-4F50-851C-D24731849451"),
                column: "order_id",
                value: Guid.Parse("A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568"));

            migrationBuilder.InsertData(
                table: "order_history",
                columns: new[] { "id", "order_id", "order_history_method_id", "description" },
                values: new object[,]
                {
                   { Guid.NewGuid(), Guid.Parse("A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568"), 1, null },
                   { Guid.NewGuid(), Guid.Parse("A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568"), 2, null },
                   { Guid.NewGuid(), Guid.Parse("A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568"), 3, "Смена статуса на \"Передано на выполнение\""},
                   { Guid.NewGuid(), Guid.Parse("A7F0A23D-74B7-4C12-86D9-1AEF2C9C5568"), 4,
                     "Назначение исполнителя: \"A4FC44C7-A880-451C-938C-78D5515201ED\""},

                   { Guid.NewGuid(), Guid.Parse("8CC409BF-33EA-4FD5-8952-28EC247D4C4B"), 1, null },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
