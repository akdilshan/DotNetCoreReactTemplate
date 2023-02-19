using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql($"SET IDENTITY_INSERT Countries ON");
            migrationBuilder.Sql($"INSERT INTO Countries (Id,Name,ISOCode) VALUES(1, 'United States', 'USA' )");
            migrationBuilder.Sql($"INSERT INTO Countries (Id,Name,ISOCode) VALUES(2, 'Australia', 'AUS' )");
            migrationBuilder.Sql($"INSERT INTO Countries (Id,Name,ISOCode) VALUES(3, 'Singapore', 'SG' )");

            migrationBuilder.Sql($"SET IDENTITY_INSERT Countries OFF");
            migrationBuilder.Sql($"SET IDENTITY_INSERT Airports ON");
            migrationBuilder.Sql($"INSERT INTO Airports (Id,Name,PrimaryCode,CountryId) VALUES(1, 'Sydney', '123SYD','2' )");
            migrationBuilder.Sql($"INSERT INTO Airports (Id,Name,PrimaryCode,CountryId) VALUES(2, 'Melbourne', '123MLB','2' )");
            migrationBuilder.Sql($"INSERT INTO Airports (Id,Name,PrimaryCode,CountryId) VALUES(3, 'New York', '123NY','1' )");
            migrationBuilder.Sql($"INSERT INTO Airports (Id,Name,PrimaryCode,CountryId) VALUES(4, 'Changi', '123CHNG','3' )");

            migrationBuilder.Sql($"SET IDENTITY_INSERT Airports OFF");
            migrationBuilder.Sql($"SET IDENTITY_INSERT Airlines ON");
            migrationBuilder.Sql($"INSERT INTO Airlines (Id,Name,Code,CountryId) VALUES(1, 'Quantas', 'QT11','2' )");
            migrationBuilder.Sql($"INSERT INTO Airlines (Id,Name,Code,CountryId) VALUES(2, 'Singapore AirLines', 'SGPAL','3' )");

            migrationBuilder.Sql($"SET IDENTITY_INSERT Airlines OFF");
            migrationBuilder.Sql($"SET IDENTITY_INSERT Flights ON");
            migrationBuilder.Sql($"INSERT INTO Flights (Id,Code,FromId, ToId, AirLineId) VALUES(1, 'UL554', 1,2,1 )");
            migrationBuilder.Sql($"INSERT INTO Flights (Id,Code,FromId, ToId, AirLineId) VALUES(2, 'UL564', 2,1,1 )");
            migrationBuilder.Sql($"INSERT INTO Flights (Id,Code,FromId, ToId, AirLineId) VALUES(3, 'ML554', 4,3,2 )");
            migrationBuilder.Sql($"INSERT INTO Flights (Id,Code,FromId, ToId, AirLineId) VALUES(4, 'ML554', 3,4,2 )");
            migrationBuilder.Sql($"INSERT INTO Flights (Id,Code,FromId, ToId, AirLineId) VALUES(5, 'ML554', 1,3,1 )");
            migrationBuilder.Sql($"INSERT INTO Flights (Id,Code,FromId, ToId, AirLineId) VALUES(6, 'ML554', 3,1,1 )");
            migrationBuilder.Sql($"INSERT INTO Flights (Id,Code,FromId, ToId, AirLineId) VALUES(7, 'ML554', 2,3,1 )");
            migrationBuilder.Sql($"INSERT INTO Flights (Id,Code,FromId, ToId, AirLineId) VALUES(8, 'ML554', 3,2,1 )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
