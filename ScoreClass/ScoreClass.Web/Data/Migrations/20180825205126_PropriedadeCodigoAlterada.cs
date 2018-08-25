using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScoreClass.Web.Data.Migrations
{
    public partial class PropriedadeCodigoAlterada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Escola_EscolaId",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Escola",
                table: "Escola");

            migrationBuilder.RenameTable(
                name: "Escola",
                newName: "Escola_1");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Matricula",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Escola_1",
                table: "Escola_1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Escola_1_EscolaId",
                table: "Turma",
                column: "EscolaId",
                principalTable: "Escola_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Escola_1_EscolaId",
                table: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Escola_1",
                table: "Escola_1");

            migrationBuilder.RenameTable(
                name: "Escola_1",
                newName: "Escola");

            migrationBuilder.AlterColumn<long>(
                name: "Codigo",
                table: "Matricula",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Escola",
                table: "Escola",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Escola_EscolaId",
                table: "Turma",
                column: "EscolaId",
                principalTable: "Escola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
