using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MigrationsSample.Migrations
{
    public partial class AddIsbnAndAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Books",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeadAuthor",
                table: "Books",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LeadAuthor",
                table: "Books");
        }
    }
}
