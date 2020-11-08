using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesLessons.Services.Migrations
{
    public partial class CodeFirstSpGetByEmployeeById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure CodeFirstSpGetByEmployeeById
                                @Id int
                                as
                                Begin
                                    Select * from Employees
                                    where Id = @id
                                End";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure CodeFirstSpGetByEmployeeById";

            migrationBuilder.Sql(procedure);
        }
    }
}
