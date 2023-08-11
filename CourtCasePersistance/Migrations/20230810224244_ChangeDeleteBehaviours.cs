using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourtCasePersistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDeleteBehaviours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseStatus",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASESTATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Court",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surename = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    ParentName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Forename = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Sex = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    JMBG = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCatalog",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    PlannedNumber = table.Column<decimal>(type: "numeric(3,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOBCATALOG", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "EmployeeInDepartment",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    No = table.Column<decimal>(type: "numeric(6,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEEINDEPARTMENT", x => new { x.EmployeeId, x.DepartmentId, x.No });
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_DEPARTMEN_DEPARTME",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_EMPLOYEEO_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    DepartmentId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Id = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    CurrentStatus = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASE", x => new { x.DepartmentId, x.TypeId, x.Id });
                    table.ForeignKey(
                        name: "FK_CASE_DEPARTMEN_DEPARTME",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CASE_RELATIONS_CASESTAT",
                        column: x => x.CurrentStatus,
                        principalTable: "CaseStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CASE_TYPE_SUBJECTT",
                        column: x => x.TypeId,
                        principalTable: "SubjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CasePhase",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Id = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASEPHASE", x => new { x.TypeId, x.Id });
                    table.ForeignKey(
                        name: "FK_CASEPHAS_FAZA_SUBJECTT",
                        column: x => x.TypeId,
                        principalTable: "SubjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobPerType",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    JobId = table.Column<decimal>(type: "numeric(4,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOBPERTYPE", x => new { x.JobId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_JOBPERTY_RELATIONS_JOBCATAL",
                        column: x => x.JobId,
                        principalTable: "JobCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JOBPERTY_RELATIONS_SUBJECTT",
                        column: x => x.TypeId,
                        principalTable: "SubjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseStatusHistory",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    DepartmentId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    StatusId = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    CaseId = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Judge = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASESTATUSHISTORY", x => new { x.DepartmentId, x.TypeId, x.CaseId, x.StatusId, x.No });
                    table.ForeignKey(
                        name: "FK_CASESTAT_RELATIONS_CASE",
                        columns: x => new { x.DepartmentId, x.TypeId, x.CaseId },
                        principalTable: "Case",
                        principalColumns: new[] { "DepartmentId", "TypeId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CASESTAT_RELATIONS_CASESTAT",
                        column: x => x.StatusId,
                        principalTable: "CaseStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourtCases",
                columns: table => new
                {
                    CourtId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    DepartmentId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    TypeId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    CaseId = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURTCASES", x => new { x.DepartmentId, x.TypeId, x.CaseId, x.CourtId, x.No });
                    table.ForeignKey(
                        name: "FK_COURTCAS_RELATIONS_CASE",
                        columns: x => new { x.DepartmentId, x.TypeId, x.CaseId },
                        principalTable: "Case",
                        principalColumns: new[] { "DepartmentId", "TypeId", "Id" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COURTCAS_RELATIONS_COURT",
                        column: x => x.CourtId,
                        principalTable: "Court",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hearing",
                columns: table => new
                {
                    CourtId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    TypeId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    DepartmentId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    CaseId = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Record = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HEARING", x => new { x.DepartmentId, x.TypeId, x.CaseId, x.CourtId, x.No });
                    table.ForeignKey(
                        name: "FK_HEARING_RELATIONS_CASE",
                        columns: x => new { x.DepartmentId, x.TypeId, x.CaseId },
                        principalTable: "Case",
                        principalColumns: new[] { "DepartmentId", "TypeId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HEARING_RELATIONS_COURT",
                        column: x => x.CourtId,
                        principalTable: "Court",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CasePhaseHistory",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    DepartmentId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    PhaseId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CaseNo = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASEPHASEHISTORY", x => new { x.DepartmentId, x.TypeId, x.CaseNo, x.PhaseId, x.No });
                    table.ForeignKey(
                        name: "FK_CASEPHAS_DURATION__CASEPHAS",
                        columns: x => new { x.TypeId, x.PhaseId },
                        principalTable: "CasePhase",
                        principalColumns: new[] { "TypeId", "Id" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CASEPHAS_FOR_CASE_CASE",
                        columns: x => new { x.DepartmentId, x.TypeId, x.CaseNo },
                        principalTable: "Case",
                        principalColumns: new[] { "DepartmentId", "TypeId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseWorker",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    DepartmentId = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    JobId = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    CaseId = table.Column<decimal>(type: "numeric(6,0)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASEWORKER", x => new { x.DepartmentId, x.CaseId, x.EmployeeId, x.JobId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_CASEWORK_RADI_NA_P_EMPLOYEE",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CASEWORK_RELATIONS_JOBPERTY",
                        columns: x => new { x.JobId, x.TypeId },
                        principalTable: "JobPerType",
                        principalColumns: new[] { "JobId", "TypeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CASEWORK_ZAPOSLENI_CASE",
                        columns: x => new { x.DepartmentId, x.TypeId, x.CaseId },
                        principalTable: "Case",
                        principalColumns: new[] { "DepartmentId", "TypeId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "CASESTATUS_FK",
                table: "Case",
                column: "CurrentStatus");

            migrationBuilder.CreateIndex(
                name: "DEPARTMENT",
                table: "Case",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "TYPE_FK",
                table: "Case",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "PHASE_FK",
                table: "CasePhase",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "FOR_CASE_FK",
                table: "CasePhaseHistory",
                columns: new[] { "DepartmentId", "TypeId", "CaseNo" });

            migrationBuilder.CreateIndex(
                name: "PHASE_DURATION_FK",
                table: "CasePhaseHistory",
                columns: new[] { "TypeId", "PhaseId" });

            migrationBuilder.CreateIndex(
                name: "CASE_FK",
                table: "CaseStatusHistory",
                columns: new[] { "DepartmentId", "TypeId", "CaseId" });

            migrationBuilder.CreateIndex(
                name: "CASE_STATUS_FK",
                table: "CaseStatusHistory",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "CASE_FK",
                table: "CaseWorker",
                columns: new[] { "DepartmentId", "TypeId", "CaseId" });

            migrationBuilder.CreateIndex(
                name: "JOB_TYPE_FK",
                table: "CaseWorker",
                columns: new[] { "JobId", "TypeId" });

            migrationBuilder.CreateIndex(
                name: "WORKER_FK",
                table: "CaseWorker",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "CASE_FK",
                table: "CourtCases",
                columns: new[] { "DepartmentId", "TypeId", "CaseId" });

            migrationBuilder.CreateIndex(
                name: "COURT_FK",
                table: "CourtCases",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "DEPARTMENT_FK",
                table: "EmployeeInDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "EMPLOYEE_FK",
                table: "EmployeeInDepartment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "CASE_FK",
                table: "Hearing",
                columns: new[] { "DepartmentId", "TypeId", "CaseId" });

            migrationBuilder.CreateIndex(
                name: "COURT_FK",
                table: "Hearing",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "JOB_FK",
                table: "JobPerType",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "TYPE_FK",
                table: "JobPerType",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasePhaseHistory");

            migrationBuilder.DropTable(
                name: "CaseStatusHistory");

            migrationBuilder.DropTable(
                name: "CaseWorker");

            migrationBuilder.DropTable(
                name: "CourtCases");

            migrationBuilder.DropTable(
                name: "EmployeeInDepartment");

            migrationBuilder.DropTable(
                name: "Hearing");

            migrationBuilder.DropTable(
                name: "CasePhase");

            migrationBuilder.DropTable(
                name: "JobPerType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Court");

            migrationBuilder.DropTable(
                name: "JobCatalog");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "CaseStatus");

            migrationBuilder.DropTable(
                name: "SubjectType");
        }
    }
}
