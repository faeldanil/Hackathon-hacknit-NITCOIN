using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ScoreClass.Web.Data.Migrations
{
    public partial class versao_ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Email_EmailNumero",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsavel_Email_EmailNumero",
                table: "Responsavel");

            migrationBuilder.RenameColumn(
                name: "EmailNumero",
                table: "Responsavel",
                newName: "EmailDescricao");

            migrationBuilder.RenameIndex(
                name: "IX_Responsavel_EmailNumero",
                table: "Responsavel",
                newName: "IX_Responsavel_EmailDescricao");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Email",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "EmailNumero",
                table: "Aluno",
                newName: "EmailDescricao");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_EmailNumero",
                table: "Aluno",
                newName: "IX_Aluno_EmailDescricao");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Email_EmailDescricao",
                table: "Aluno",
                column: "EmailDescricao",
                principalTable: "Email",
                principalColumn: "Descricao",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsavel_Email_EmailDescricao",
                table: "Responsavel",
                column: "EmailDescricao",
                principalTable: "Email",
                principalColumn: "Descricao",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Email_EmailDescricao",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsavel_Email_EmailDescricao",
                table: "Responsavel");

            migrationBuilder.RenameColumn(
                name: "EmailDescricao",
                table: "Responsavel",
                newName: "EmailNumero");

            migrationBuilder.RenameIndex(
                name: "IX_Responsavel_EmailDescricao",
                table: "Responsavel",
                newName: "IX_Responsavel_EmailNumero");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Email",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "EmailDescricao",
                table: "Aluno",
                newName: "EmailNumero");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_EmailDescricao",
                table: "Aluno",
                newName: "IX_Aluno_EmailNumero");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Email_EmailNumero",
                table: "Aluno",
                column: "EmailNumero",
                principalTable: "Email",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsavel_Email_EmailNumero",
                table: "Responsavel",
                column: "EmailNumero",
                principalTable: "Email",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
