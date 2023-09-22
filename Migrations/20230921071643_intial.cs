using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIAFFS.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    ref_code = table.Column<string>(type: "character varying", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    ref_code = table.Column<string>(type: "character varying", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "financial_years",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_years", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project_natures",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_natures", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prroject_type",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    project_nature_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prroject_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_prroject_type_project_natures_project_nature_id",
                        column: x => x.project_nature_id,
                        principalTable: "project_natures",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    mode = table.Column<char>(type: "char", nullable: true),
                    department_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    project_nature_id = table.Column<Guid>(type: "uuid", nullable: true),
                    project_type_id = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    financial_year_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    update_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_projects_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_projects_financial_years_financial_year_id",
                        column: x => x.financial_year_id,
                        principalTable: "financial_years",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_projects_project_natures_project_nature_id",
                        column: x => x.project_nature_id,
                        principalTable: "project_natures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_projects_prroject_type_project_type_id",
                        column: x => x.project_type_id,
                        principalTable: "prroject_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sites",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    district_id = table.Column<Guid>(type: "uuid", nullable: true),
                    project_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sites", x => x.id);
                    table.ForeignKey(
                        name: "FK_sites_districts_district_id",
                        column: x => x.district_id,
                        principalTable: "districts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_sites_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_projects_department_id",
                table: "projects",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_financial_year_id",
                table: "projects",
                column: "financial_year_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_project_nature_id",
                table: "projects",
                column: "project_nature_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_project_type_id",
                table: "projects",
                column: "project_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_prroject_type_project_nature_id",
                table: "prroject_type",
                column: "project_nature_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_district_id",
                table: "sites",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_sites_project_id",
                table: "sites",
                column: "project_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sites");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "financial_years");

            migrationBuilder.DropTable(
                name: "prroject_type");

            migrationBuilder.DropTable(
                name: "project_natures");
        }
    }
}
