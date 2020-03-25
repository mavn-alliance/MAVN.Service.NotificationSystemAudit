using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lykke.Service.NotificationSystemAudit.MsSqlRepositories.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auditmessage");

            migrationBuilder.CreateTable(
                name: "AuditMessages",
                schema: "auditmessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTimestamp = table.Column<DateTime>(nullable: false),
                    SentTimestamp = table.Column<DateTime>(nullable: false),
                    MessageId = table.Column<string>(maxLength: 100, nullable: false),
                    MessageType = table.Column<string>(maxLength: 30, nullable: false),
                    CustomerId = table.Column<string>(maxLength: 100, nullable: false),
                    SubjectTemplateId = table.Column<string>(maxLength: 100, nullable: true),
                    MessageTemplateId = table.Column<string>(maxLength: 100, nullable: false),
                    Source = table.Column<string>(maxLength: 100, nullable: false),
                    CallType = table.Column<int>(maxLength: 20, nullable: false),
                    FormattingStatus = table.Column<int>(maxLength: 40, nullable: false),
                    FormattingComment = table.Column<string>(maxLength: 10000, nullable: true),
                    DeliveryStatus = table.Column<int>(maxLength: 40, nullable: false),
                    DeliveryComment = table.Column<string>(maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditMessages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditMessages_CustomerId",
                schema: "auditmessage",
                table: "AuditMessages",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMessages_DeliveryStatus",
                schema: "auditmessage",
                table: "AuditMessages",
                column: "DeliveryStatus");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMessages_MessageType",
                schema: "auditmessage",
                table: "AuditMessages",
                column: "MessageType");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMessages_SentTimestamp",
                schema: "auditmessage",
                table: "AuditMessages",
                column: "SentTimestamp");

            migrationBuilder.CreateIndex(
                name: "IX_AuditMessages_Source",
                schema: "auditmessage",
                table: "AuditMessages",
                column: "Source");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditMessages",
                schema: "auditmessage");
        }
    }
}
