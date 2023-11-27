using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressDelivery.Persistence.Migrations
{
    public partial class FillDictionaryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ExecutorStatus (Name, Code, IsActual) " +
                                     "VALUES ('Ожидает заказа', 'wait', 1), " +
                                             "('Выполняет заказ', 'submitted', 1), " +
                                             "('Назначается заказ', 'orderselection', 1);");

            migrationBuilder.Sql("INSERT INTO OrderStatus (Name, Code, IsActual) " +
                                 "VALUES ('Новый', 'new', 1), " +
                                         "('Ожидает', 'wait', 1), " +
                                         "('Передано на выполнение', 'submitted', 1), " +
                                         "('Выполнен', 'completed', 1), " +
                                         "('Отменен', 'cancelled', 1), " +
                                         "('Удален', 'deleted', 1);");

            migrationBuilder.Sql("INSERT INTO CargoType (Name, Code, IsActual) " +
                                 "VALUES ('Крупногабаритные грузы', 'bulky', 1), " +
                                         "('Ценные грузы', 'valuable', 1), " +
                                         "('Перечисляемые грузы', 'listed', 1), " +
                                         "('Техническое оборудование', 'technicalequipment', 1);");

            migrationBuilder.Sql("INSERT INTO OrderHistoryMethod (Name, Code, IsActual) " +
                                 "VALUES ('Создание заказа', 'create', 1)," +
                                         "('Редактирование заказа', 'edit', 1), " +
                                         "('Изменение статуса заказа', 'updatestatus', 1), " +
                                         "('Назначение исполнителя', 'submittedexecution', 1), " +
                                         "('Удаление заказа', 'delete', 1);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
