using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    public partial class addedNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_IdentityUserID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSections_AspNetUsers_IdentityUserID",
                table: "CourseSections");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSections_Courses_CourseID",
                table: "CourseSections");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionScores_AspNetUsers_IdentityUserID",
                table: "CourseSectionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionScores_Courses_CourseID",
                table: "CourseSectionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionScores_CourseSections_CourseSectionID",
                table: "CourseSectionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_CourseSections_CourseSectionId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionScore_AspNetUsers_IdentityUserID",
                table: "QuestionScore");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionScore_Courses_CourseID",
                table: "QuestionScore");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionScore_CourseSections_CourseSectionID",
                table: "QuestionScore");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionScore_Questions_QuestionID",
                table: "QuestionScore");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "QuestionScore",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserID",
                table: "QuestionScore",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CourseSectionID",
                table: "QuestionScore",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "QuestionScore",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CourseSectionId",
                table: "Questions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Questions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserID",
                table: "CourseSectionScores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CourseSectionID",
                table: "CourseSectionScores",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "CourseSectionScores",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserID",
                table: "CourseSections",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "CourseSections",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserID",
                table: "Courses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionID",
                table: "Answers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_IdentityUserID",
                table: "Courses",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSections_AspNetUsers_IdentityUserID",
                table: "CourseSections",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSections_Courses_CourseID",
                table: "CourseSections",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionScores_AspNetUsers_IdentityUserID",
                table: "CourseSectionScores",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionScores_Courses_CourseID",
                table: "CourseSectionScores",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionScores_CourseSections_CourseSectionID",
                table: "CourseSectionScores",
                column: "CourseSectionID",
                principalTable: "CourseSections",
                principalColumn: "CourseSectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseID",
                table: "Questions",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_CourseSections_CourseSectionId",
                table: "Questions",
                column: "CourseSectionId",
                principalTable: "CourseSections",
                principalColumn: "CourseSectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionScore_AspNetUsers_IdentityUserID",
                table: "QuestionScore",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionScore_Courses_CourseID",
                table: "QuestionScore",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionScore_CourseSections_CourseSectionID",
                table: "QuestionScore",
                column: "CourseSectionID",
                principalTable: "CourseSections",
                principalColumn: "CourseSectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionScore_Questions_QuestionID",
                table: "QuestionScore",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_IdentityUserID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSections_AspNetUsers_IdentityUserID",
                table: "CourseSections");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSections_Courses_CourseID",
                table: "CourseSections");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionScores_AspNetUsers_IdentityUserID",
                table: "CourseSectionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionScores_Courses_CourseID",
                table: "CourseSectionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionScores_CourseSections_CourseSectionID",
                table: "CourseSectionScores");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_CourseSections_CourseSectionId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionScore_AspNetUsers_IdentityUserID",
                table: "QuestionScore");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionScore_Courses_CourseID",
                table: "QuestionScore");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionScore_CourseSections_CourseSectionID",
                table: "QuestionScore");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionScore_Questions_QuestionID",
                table: "QuestionScore");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "QuestionScore",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserID",
                table: "QuestionScore",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseSectionID",
                table: "QuestionScore",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "QuestionScore",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseSectionId",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserID",
                table: "CourseSectionScores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseSectionID",
                table: "CourseSectionScores",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "CourseSectionScores",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserID",
                table: "CourseSections",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "CourseSections",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserID",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionID",
                table: "Answers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_IdentityUserID",
                table: "Courses",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSections_AspNetUsers_IdentityUserID",
                table: "CourseSections",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSections_Courses_CourseID",
                table: "CourseSections",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionScores_AspNetUsers_IdentityUserID",
                table: "CourseSectionScores",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionScores_Courses_CourseID",
                table: "CourseSectionScores",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionScores_CourseSections_CourseSectionID",
                table: "CourseSectionScores",
                column: "CourseSectionID",
                principalTable: "CourseSections",
                principalColumn: "CourseSectionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseID",
                table: "Questions",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_CourseSections_CourseSectionId",
                table: "Questions",
                column: "CourseSectionId",
                principalTable: "CourseSections",
                principalColumn: "CourseSectionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionScore_AspNetUsers_IdentityUserID",
                table: "QuestionScore",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionScore_Courses_CourseID",
                table: "QuestionScore",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionScore_CourseSections_CourseSectionID",
                table: "QuestionScore",
                column: "CourseSectionID",
                principalTable: "CourseSections",
                principalColumn: "CourseSectionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionScore_Questions_QuestionID",
                table: "QuestionScore",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
