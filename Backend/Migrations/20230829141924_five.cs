﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Categories_CategoryId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CategoryId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Concerts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_CategoryId",
                table: "Concerts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Categories_CategoryId",
                table: "Concerts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Categories_CategoryId",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_CategoryId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Concerts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CategoryId",
                table: "Purchases",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Categories_CategoryId",
                table: "Purchases",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
