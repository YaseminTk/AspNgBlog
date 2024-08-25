using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blog");

            migrationBuilder.CreateTable(
                name: "user",
                schema: "blog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    changed_by_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changed_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_user_changed_by_id",
                        column: x => x.changed_by_id,
                        principalSchema: "blog",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "post",
                schema: "blog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changed_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.id);
                    table.ForeignKey(
                        name: "FK_post_user_created_by_id",
                        column: x => x.created_by_id,
                        principalSchema: "blog",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "blog",
                table: "user",
                columns: new[] { "id", "changed_at", "changed_by_id", "created_at", "full_name", "password_hash", "role", "user_name" },
                values: new object[] { -1, null, null, new DateTime(2024, 8, 26, 1, 4, 28, 814, DateTimeKind.Local).AddTicks(2063), "Admin", "AQAAAAIAAYagAAAAEDjMnrp33rrvr9tkGu7X7RTRFaOqSbiFTsbTThsE7CvEAp1Q0plN8H7P5Sr7mwD04Q==", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_post_created_by_id",
                schema: "blog",
                table: "post",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_changed_by_id",
                schema: "blog",
                table: "user",
                column: "changed_by_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post",
                schema: "blog");

            migrationBuilder.DropTable(
                name: "user",
                schema: "blog");
        }
    }
}
