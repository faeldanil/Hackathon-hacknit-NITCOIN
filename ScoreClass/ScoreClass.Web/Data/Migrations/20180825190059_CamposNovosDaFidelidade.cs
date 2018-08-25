using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScoreClass.Web.Data.Migrations
{
    public partial class CamposNovosDaFidelidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Voucher",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TipoValor",
                table: "Voucher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Responsavel",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxaConversao",
                table: "Fidelidade",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "TipoValor",
                table: "Fidelidade",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Fidelidade",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoValor",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "TipoValor",
                table: "Fidelidade");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Fidelidade");

            migrationBuilder.AlterColumn<int>(
                name: "Valor",
                table: "Voucher",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxaConversao",
                table: "Fidelidade",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
