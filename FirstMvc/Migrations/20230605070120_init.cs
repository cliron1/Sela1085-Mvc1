using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMvc.Migrations {
	/// <inheritdoc />
	public partial class init : Migration {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Photos",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<int>(type: "int", nullable: false),
					Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Photos", x => x.Id);
					table.ForeignKey(
						name: "FK_Photos_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Comment",
				columns: table => new {
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					PhotoId = table.Column<int>(type: "int", nullable: false),
					Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Comment", x => x.Id);
					table.ForeignKey(
						name: "FK_Comment_Photos_PhotoId",
						column: x => x.PhotoId,
						principalTable: "Photos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Comment_PhotoId",
				table: "Comment",
				column: "PhotoId");

			migrationBuilder.CreateIndex(
				name: "IX_Photos_UserId",
				table: "Photos",
				column: "UserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "Comment");

			migrationBuilder.DropTable(
				name: "Photos");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
