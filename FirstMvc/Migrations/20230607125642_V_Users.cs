using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMvc.Migrations
{
    /// <inheritdoc />
    public partial class V_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE View [dbo].[V_Users]
as
With P as (
	Select UserId, Count(0) as Cnt from Photos Group by UserId
)
Select
	U.*, Isnull(P.Cnt, 0) as Cnt
from Users as U
	Left Outer Join P on P.UserId = U.Id
GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP View [dbo].[V_Users]");
        }
    }
}
