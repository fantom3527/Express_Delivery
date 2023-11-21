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


            migrationBuilder.Sql("INSERT INTO Cargo(Id, CargoTypeId, Name, Description) " +
                                 "VALUES " +
                                 "('6F9619FF-8B86-D011-B42D-00C04FC964FF', 1, 'CargoName1', 'Description1'), " +
                                 "('6F9619FF-8B86-D011-B42D-00C04FC964FF', 2, 'CargoName2', 'Description2'), " +
                                 "('6F9619FF-8B86-D011-B42D-00C04FC964FF', 3, 'CargoName3', 'Description3');");

            migrationBuilder.Sql("INSERT INTO User(Id, Name, Description) " +
                                 "VALUES " +
                                 "('6F9619FF-8B86-D011-B42D-00C04FC964FF', 'John Doe', 'Description 1'), " +
                                 "('6F9619FF-8B86-D011-B42D-00C04FC964FF', 'Jane Smith', 'Description 2'), " +
                                 "('6F9619FF-8B86-D011-B42D-00C04FC964FF', 'Alice Johnson', 'Description 3');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
