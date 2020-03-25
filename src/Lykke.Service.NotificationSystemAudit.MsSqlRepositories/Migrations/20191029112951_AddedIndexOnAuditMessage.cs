using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.NotificationSystemAudit.MsSqlRepositories.Migrations
{
    public partial class AddedIndexOnAuditMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_audit_messages_message_id",
                schema: "auditmessage",
                table: "audit_messages",
                column: "message_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_audit_messages_message_id",
                schema: "auditmessage",
                table: "audit_messages");
        }
    }
}
