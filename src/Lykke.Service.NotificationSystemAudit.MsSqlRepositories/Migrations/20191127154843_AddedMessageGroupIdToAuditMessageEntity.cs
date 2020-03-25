using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.NotificationSystemAudit.MsSqlRepositories.Migrations
{
    public partial class AddedMessageGroupIdToAuditMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "message_group_id",
                schema: "auditmessage",
                table: "audit_messages",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_audit_messages_message_group_id",
                schema: "auditmessage",
                table: "audit_messages",
                column: "message_group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_audit_messages_message_group_id",
                schema: "auditmessage",
                table: "audit_messages");

            migrationBuilder.DropColumn(
                name: "message_group_id",
                schema: "auditmessage",
                table: "audit_messages");
        }
    }
}
