using Microsoft.EntityFrameworkCore.Migrations;

namespace FurnitureBy.Data.Migrations
{
    public partial class AddCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "Categories",
                columns: new[] { "Id", "Description", "IsShow", "Name", "ParentId" },
                values: new object[,]
                {
                    { "967ED34D-3E98-4DEC-B108-A76561478E77", "", true, "Столы-транформеры", 4 },
                    { "EE175C2A-F427-4E33-B2A2-D202D7F8C831", "", true, "Для одежды", 3 },
                    { "AB01742F-413A-420B-8D7C-416F31753AA2", "", true, "Купе", 3 },
                    { "27B09768-FC8F-49C5-B298-EA6986B74FC6", "", true, "Кровати", 2 },
                    { "C6FFCD65-2284-4778-9976-9A380BA22784", "", true, "Софы", 2 },
                    { "4451E155-8F35-483C-8A4A-2C15B8DCFD67", "", true, "Модульные", 2 },
                    { "C1681BE4-9A9D-4C83-9ECC-44978186BDBF", "", true, "Угловые", 2 },
                    { "C1627F62-7006-4993-8ACB-786F4321370F", "", true, "2-ярусные", 1 },
                    { "7CDACD63-E07E-470D-B59A-3111C5B31CC3", "", true, "Детские", 1 },
                    { "3E095A2A-E65D-4889-B239-F95F7C8A8723", "", true, "1-местные", 1 },
                    { "5FD132AF-DF42-4D16-B099-8F639BE6B4AB", "", true, "2-местные", 1 },
                    { "C2FDC337-1567-4B04-8827-E639725BB929", "", true, "Стулья классические", 5 },
                    { "F7B6F7DC-84EB-4D24-9CFD-E4FD27AA15EA", "", true, "Стулья для сада", 5 },
                    { "0C5549DB-2EE2-46F1-B0BC-3568FA1F9C32", "", true, "Подушка для стула", 5 },
                    { "3D8BDA65-0354-45F1-AEFE-D8C8DF0E6CF8", "", true, "Барные стулья", 5 },
                    { "B09F0A09-0D6C-47BD-94E1-4C1BF0382C30", "", true, "Стулья компьютерные", 5 },
                    { "47F4AC2C-68DA-4E17-A557-1C56630877CE", "", true, "Табуреты", 5 },
                    { "CE0EB21A-B1DD-41A7-8DDC-B44364A4BA3E", "", true, "Стулья обеденные", 5 },
                    { "915AB52E-9E7B-4536-ACBB-AEB4CC4720D2", "", true, "Столы туалетные", 4 },
                    { "0FFC296E-8DA3-415F-9EC1-2EF0C164A15F", "", true, "Столы для сада", 4 },
                    { "7F2C5637-A686-44C2-BD52-B48ECE418CC4", "", true, "Столы журнальные", 4 },
                    { "DD6A604D-118F-4DE6-AA4B-F1EF9AEE3A1B", "", true, "Столы-книги", 4 },
                    { "6351A626-BB4A-43DA-994A-3A9F5A9F7B0C", "", true, "Столы компьютерные", 4 },
                    { "08EA2E88-D576-4008-9070-EA21CC91067E", "", true, "Столы обеденные", 4 },
                    { "99322F12-450D-488D-AFC2-E1EC06CFBC9D", "", true, "Кухонные", 3 },
                    { "CB0326CE-F5FB-42F3-8977-08383E9B5DAF", "", true, "Книжные", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "08EA2E88-D576-4008-9070-EA21CC91067E");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "0C5549DB-2EE2-46F1-B0BC-3568FA1F9C32");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "0FFC296E-8DA3-415F-9EC1-2EF0C164A15F");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "27B09768-FC8F-49C5-B298-EA6986B74FC6");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3D8BDA65-0354-45F1-AEFE-D8C8DF0E6CF8");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3E095A2A-E65D-4889-B239-F95F7C8A8723");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4451E155-8F35-483C-8A4A-2C15B8DCFD67");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "47F4AC2C-68DA-4E17-A557-1C56630877CE");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5FD132AF-DF42-4D16-B099-8F639BE6B4AB");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6351A626-BB4A-43DA-994A-3A9F5A9F7B0C");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7CDACD63-E07E-470D-B59A-3111C5B31CC3");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7F2C5637-A686-44C2-BD52-B48ECE418CC4");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "915AB52E-9E7B-4536-ACBB-AEB4CC4720D2");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "967ED34D-3E98-4DEC-B108-A76561478E77");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "99322F12-450D-488D-AFC2-E1EC06CFBC9D");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "AB01742F-413A-420B-8D7C-416F31753AA2");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "B09F0A09-0D6C-47BD-94E1-4C1BF0382C30");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "C1627F62-7006-4993-8ACB-786F4321370F");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "C1681BE4-9A9D-4C83-9ECC-44978186BDBF");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "C2FDC337-1567-4B04-8827-E639725BB929");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "C6FFCD65-2284-4778-9976-9A380BA22784");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "CB0326CE-F5FB-42F3-8977-08383E9B5DAF");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "CE0EB21A-B1DD-41A7-8DDC-B44364A4BA3E");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "DD6A604D-118F-4DE6-AA4B-F1EF9AEE3A1B");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "EE175C2A-F427-4E33-B2A2-D202D7F8C831");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Categories",
                keyColumn: "Id",
                keyValue: "F7B6F7DC-84EB-4D24-9CFD-E4FD27AA15EA");
        }
    }
}
