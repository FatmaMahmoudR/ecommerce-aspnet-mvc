using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce.Migrations
{
    /// <inheritdoc />
    public partial class identityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Sellers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Sellers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Sellers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Buyers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Buyers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Buyers",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Sellers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Sellers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Buyers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Buyers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Buyers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Buyers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Buyers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Buyers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Buyers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Sellers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "Sellers",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Sellers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Buyers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "Buyers",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Buyers",
                newName: "Phone");
        }
    }
}
