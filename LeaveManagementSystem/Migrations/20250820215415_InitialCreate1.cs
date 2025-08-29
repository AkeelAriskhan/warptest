using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leave_balance_history_employees_changed_by",
                table: "leave_balance_history");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_balance_history_employees_employee_id",
                table: "leave_balance_history");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_balance_history_leave_types_leave_type_id",
                table: "leave_balance_history");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_balances_employees_employee_id",
                table: "leave_balances");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_employees_employee_id",
                table: "notifications");

            migrationBuilder.AddForeignKey(
                name: "FK_leave_balance_history_employees_changed_by",
                table: "leave_balance_history",
                column: "changed_by",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_balance_history_employees_employee_id",
                table: "leave_balance_history",
                column: "employee_id",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_balance_history_leave_types_leave_type_id",
                table: "leave_balance_history",
                column: "leave_type_id",
                principalTable: "leave_types",
                principalColumn: "leave_type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_balances_employees_employee_id",
                table: "leave_balances",
                column: "employee_id",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_employees_employee_id",
                table: "notifications",
                column: "employee_id",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leave_balance_history_employees_changed_by",
                table: "leave_balance_history");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_balance_history_employees_employee_id",
                table: "leave_balance_history");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_balance_history_leave_types_leave_type_id",
                table: "leave_balance_history");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_balances_employees_employee_id",
                table: "leave_balances");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_employees_employee_id",
                table: "notifications");

            migrationBuilder.AddForeignKey(
                name: "FK_leave_balance_history_employees_changed_by",
                table: "leave_balance_history",
                column: "changed_by",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_balance_history_employees_employee_id",
                table: "leave_balance_history",
                column: "employee_id",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_balance_history_leave_types_leave_type_id",
                table: "leave_balance_history",
                column: "leave_type_id",
                principalTable: "leave_types",
                principalColumn: "leave_type_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_balances_employees_employee_id",
                table: "leave_balances",
                column: "employee_id",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_employees_employee_id",
                table: "notifications",
                column: "employee_id",
                principalTable: "employees",
                principalColumn: "employee_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
