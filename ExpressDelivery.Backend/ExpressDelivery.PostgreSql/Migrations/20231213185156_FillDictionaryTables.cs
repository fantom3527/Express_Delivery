using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressDelivery.PostgreSql.Migrations
{
    public partial class FillDictionaryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "executor_status",
               columns: new[] { "name", "code", "is_actual" },
               values: new object[,]
               {
                    { "Ожидает заказа", "wait", true },
                    { "Выполняет заказ", "executesorder", true },
                    { "Назначается заказ", "orderselection", true }
               });

            migrationBuilder.InsertData(
                table: "order_status",
                columns: new[] { "name", "code", "is_actual" },
                values: new object[,]
                {
                    { "Новый", "new", true },
                    { "Ожидает", "wait", true },
                    { "Передано на выполнение", "submitted", true },
                    { "Выполнен", "completed", true },
                    { "Отменен", "cancelled", true },
                    { "Удален", "deleted", true }
                });

            migrationBuilder.InsertData(
                table: "cargo_type",
                columns: new[] { "name", "code", "is_actual" },
                values: new object[,]
                {
                    { "Крупногабаритные грузы", "bulky", true },
                    { "Ценные грузы", "valuable", true },
                    { "Перечисляемые грузы", "listed", true },
                    { "Техническое оборудование", "technicalequipment", true },
                });

            migrationBuilder.InsertData(
                table: "order_history_method",
                columns: new[] { "name", "code", "is_actual" },
                values: new object[,]
                {
                    { "Создание заказа", "create", true },
                    { "Редактирование заказа", "edit", true },
                    { "Изменение статуса заказа", "updatestatus", true },
                    { "Назначение исполнителя", "submittedexecution", true },
                    { "Удаление заказа", "delete", true },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
