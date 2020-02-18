﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCSClasses.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    RateOfPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: true),
                    MiddleInitial = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    DateOfHire = table.Column<DateTime>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task Skill",
                columns: table => new
                {
                    TaskSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfEmployeesNeeded = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task Skill", x => x.TaskSkillId);
                    table.ForeignKey(
                        name: "FK_Task Skill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task Skill_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee Skill",
                columns: table => new
                {
                    EmployeeSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee Skill", x => x.EmployeeSkillId);
                    table.ForeignKey(
                        name: "FK_Employee Skill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee Skill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    EstimatedStartDate = table.Column<DateTime>(nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(nullable: false),
                    Budget = table.Column<int>(nullable: false),
                    ActualStartDate = table.Column<DateTime>(nullable: false),
                    ActualEndDate = table.Column<DateTime>(nullable: false),
                    ActualCost = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project Schedule",
                columns: table => new
                {
                    ProjectScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project Schedule", x => x.ProjectScheduleId);
                    table.ForeignKey(
                        name: "FK_Project Schedule_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project Schedule Task",
                columns: table => new
                {
                    ProjectScheduleTaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectScheduleId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project Schedule Task", x => x.ProjectScheduleTaskId);
                    table.ForeignKey(
                        name: "FK_Project Schedule Task_Project Schedule_ProjectScheduleId",
                        column: x => x.ProjectScheduleId,
                        principalTable: "Project Schedule",
                        principalColumn: "ProjectScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project Schedule Task_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectScheduleTaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Project Schedule Task_ProjectScheduleTaskId",
                        column: x => x.ProjectScheduleTaskId,
                        principalTable: "Project Schedule Task",
                        principalColumn: "ProjectScheduleTaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work Log",
                columns: table => new
                {
                    WorkLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    TotalHoursWorked = table.Column<int>(nullable: false),
                    AssignmentId = table.Column<int>(nullable: false),
                    BillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work Log", x => x.WorkLogId);
                    table.ForeignKey(
                        name: "FK_Work Log_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work Log_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_EmployeeId",
                table: "Assignment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ProjectScheduleTaskId",
                table: "Assignment",
                column: "ProjectScheduleTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RegionId",
                table: "Customer",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RegionId",
                table: "Employee",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee Skill_EmployeeId",
                table: "Employee Skill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee Skill_SkillId",
                table: "Employee Skill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerId",
                table: "Project",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EmployeeId",
                table: "Project",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project Schedule_ProjectId",
                table: "Project Schedule",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project Schedule Task_ProjectScheduleId",
                table: "Project Schedule Task",
                column: "ProjectScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Project Schedule Task_TaskId",
                table: "Project Schedule Task",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task Skill_SkillId",
                table: "Task Skill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Task Skill_TaskId",
                table: "Task Skill",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Work Log_AssignmentId",
                table: "Work Log",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Work Log_BillId",
                table: "Work Log",
                column: "BillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee Skill");

            migrationBuilder.DropTable(
                name: "Task Skill");

            migrationBuilder.DropTable(
                name: "Work Log");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Project Schedule Task");

            migrationBuilder.DropTable(
                name: "Project Schedule");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
