using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVN.Service.NotificationSystemAudit.MsSqlRepositories.Migrations
{
    public partial class AddedColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditMessages",
                schema: "auditmessage",
                table: "AuditMessages");

            migrationBuilder.RenameTable(
                name: "AuditMessages",
                schema: "auditmessage",
                newName: "audit_messages",
                newSchema: "auditmessage");

            migrationBuilder.RenameColumn(
                name: "Source",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "source");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SubjectTemplateId",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "subject_template_id");

            migrationBuilder.RenameColumn(
                name: "SentTimestamp",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "sent_timestamp");

            migrationBuilder.RenameColumn(
                name: "MessageType",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "message_type");

            migrationBuilder.RenameColumn(
                name: "MessageTemplateId",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "message_template_id");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "message_id");

            migrationBuilder.RenameColumn(
                name: "FormattingStatus",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "formatting_status");

            migrationBuilder.RenameColumn(
                name: "FormattingComment",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "formatting_comment");

            migrationBuilder.RenameColumn(
                name: "DeliveryStatus",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "delivery_status");

            migrationBuilder.RenameColumn(
                name: "DeliveryComment",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "delivery_comment");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "CreationTimestamp",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "creation_timestamp");

            migrationBuilder.RenameColumn(
                name: "CallType",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "call_type");

            migrationBuilder.RenameIndex(
                name: "IX_AuditMessages_Source",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "IX_audit_messages_source");

            migrationBuilder.RenameIndex(
                name: "IX_AuditMessages_SentTimestamp",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "IX_audit_messages_sent_timestamp");

            migrationBuilder.RenameIndex(
                name: "IX_AuditMessages_MessageType",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "IX_audit_messages_message_type");

            migrationBuilder.RenameIndex(
                name: "IX_AuditMessages_DeliveryStatus",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "IX_audit_messages_delivery_status");

            migrationBuilder.RenameIndex(
                name: "IX_AuditMessages_CustomerId",
                schema: "auditmessage",
                table: "audit_messages",
                newName: "IX_audit_messages_customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_audit_messages",
                schema: "auditmessage",
                table: "audit_messages",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_audit_messages",
                schema: "auditmessage",
                table: "audit_messages");

            migrationBuilder.RenameTable(
                name: "audit_messages",
                schema: "auditmessage",
                newName: "AuditMessages",
                newSchema: "auditmessage");

            migrationBuilder.RenameColumn(
                name: "source",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "subject_template_id",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "SubjectTemplateId");

            migrationBuilder.RenameColumn(
                name: "sent_timestamp",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "SentTimestamp");

            migrationBuilder.RenameColumn(
                name: "message_type",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "MessageType");

            migrationBuilder.RenameColumn(
                name: "message_template_id",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "MessageTemplateId");

            migrationBuilder.RenameColumn(
                name: "message_id",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "formatting_status",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "FormattingStatus");

            migrationBuilder.RenameColumn(
                name: "formatting_comment",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "FormattingComment");

            migrationBuilder.RenameColumn(
                name: "delivery_status",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "DeliveryStatus");

            migrationBuilder.RenameColumn(
                name: "delivery_comment",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "DeliveryComment");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "creation_timestamp",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "CreationTimestamp");

            migrationBuilder.RenameColumn(
                name: "call_type",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "CallType");

            migrationBuilder.RenameIndex(
                name: "IX_audit_messages_source",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "IX_AuditMessages_Source");

            migrationBuilder.RenameIndex(
                name: "IX_audit_messages_sent_timestamp",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "IX_AuditMessages_SentTimestamp");

            migrationBuilder.RenameIndex(
                name: "IX_audit_messages_message_type",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "IX_AuditMessages_MessageType");

            migrationBuilder.RenameIndex(
                name: "IX_audit_messages_delivery_status",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "IX_AuditMessages_DeliveryStatus");

            migrationBuilder.RenameIndex(
                name: "IX_audit_messages_customer_id",
                schema: "auditmessage",
                table: "AuditMessages",
                newName: "IX_AuditMessages_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditMessages",
                schema: "auditmessage",
                table: "AuditMessages",
                column: "Id");
        }
    }
}
