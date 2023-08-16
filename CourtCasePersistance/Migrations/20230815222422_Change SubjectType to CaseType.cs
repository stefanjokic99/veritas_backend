using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourtCasePersistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSubjectTypetoCaseType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CASE_TYPE_SUBJECTT",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_CASEPHAS_FAZA_SUBJECTT",
                table: "CasePhase");

            migrationBuilder.DropForeignKey(
                name: "FK_JOBPERTY_RELATIONS_SUBJECTT",
                table: "JobPerType");

            migrationBuilder.DropTable(
                name: "SubjectType");

            migrationBuilder.CreateTable(
                name: "CaseType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBJECTTYPE", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CASE_TYPE_SUBJECTT",
                table: "Case",
                column: "TypeId",
                principalTable: "CaseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CASEPHAS_FAZA_SUBJECTT",
                table: "CasePhase",
                column: "TypeId",
                principalTable: "CaseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JOBPERTY_RELATIONS_SUBJECTT",
                table: "JobPerType",
                column: "TypeId",
                principalTable: "CaseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CASE_TYPE_SUBJECTT",
                table: "Case");

            migrationBuilder.DropForeignKey(
                name: "FK_CASEPHAS_FAZA_SUBJECTT",
                table: "CasePhase");

            migrationBuilder.DropForeignKey(
                name: "FK_JOBPERTY_RELATIONS_SUBJECTT",
                table: "JobPerType");

            migrationBuilder.DropTable(
                name: "CaseType");

            migrationBuilder.CreateTable(
                name: "SubjectType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBJECTTYPE", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CASE_TYPE_SUBJECTT",
                table: "Case",
                column: "TypeId",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CASEPHAS_FAZA_SUBJECTT",
                table: "CasePhase",
                column: "TypeId",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JOBPERTY_RELATIONS_SUBJECTT",
                table: "JobPerType",
                column: "TypeId",
                principalTable: "SubjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
