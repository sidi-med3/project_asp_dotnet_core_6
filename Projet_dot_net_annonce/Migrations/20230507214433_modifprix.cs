using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_dot_net_annonce.Migrations
{
    /// <inheritdoc />
    public partial class modifprix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Prix",
                table: "Annonces",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Annonces");
        }
    }
}
