using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4WebExample.Migrations
{
    /// <inheritdoc />
    public partial class AddLastLoginToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredAt",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegisteredAt",
                table: "AspNetUsers");
        }
    }
}
