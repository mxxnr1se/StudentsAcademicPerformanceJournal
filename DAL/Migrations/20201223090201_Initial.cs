using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    AvgScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, "IS-11" },
                    { 2, "IS-12" },
                    { 3, "IS-13" },
                    { 4, "IS-21" },
                    { 5, "IS-22" },
                    { 6, "IS-23" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Information Systems" },
                    { 2, "Computer Science" },
                    { 3, "Software Engineering" },
                    { 4, "Artificial Intelligence" },
                    { 5, "Network engineering" },
                    { 6, "Data analytics" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 1, "Kylo", 1, "Rowland" },
                    { 28, "Ariana", 6, "Hernandez" },
                    { 27, "Bianca", 6, "Bradford" },
                    { 26, "Nelson", 6, "Stark" },
                    { 25, "Johnathan", 5, "Howell" },
                    { 24, "Sonia", 5, "Rose" },
                    { 23, "Carter", 5, "Page" },
                    { 22, "Odin", 5, "Haley" },
                    { 21, "Elsa", 5, "Holloway" },
                    { 20, "Elliott", 4, "Copeland" },
                    { 19, "Isaac", 4, "Benton" },
                    { 18, "Maribel", 4, "Barnes" },
                    { 17, "Erik", 4, "Cunningham" },
                    { 16, "Catherine", 4, "Murillo" },
                    { 15, "Jaylan", 3, "Sloan" },
                    { 14, "Nelson", 3, "" },
                    { 13, "Jermaine", 3, "Daugherty" },
                    { 12, "Kya", 3, "Turnbull" },
                    { 11, "Graeme", 3, "Dudley" },
                    { 10, "June", 2, "Griffiths" },
                    { 9, "Lucca", 2, "Weiss" },
                    { 8, "Tamera ", 2, "Kramer" },
                    { 7, "Ansh", 2, "Horne" },
                    { 6, "Aaliya", 2, "Arias" },
                    { 5, "Cienna", 1, "Nixon" },
                    { 4, "Shaunie", 1, "Broughton" },
                    { 3, "Summer", 1, "Muir" },
                    { 2, "Mylee", 1, "Millington" },
                    { 29, "Darryl", 6, "Nielsen" },
                    { 30, "Brooke", 6, "Roberts" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Score", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 8.23m, 1, 1 },
                    { 67, 5.74m, 22, 5 },
                    { 62, 9.75m, 22, 4 },
                    { 71, 6.20m, 21, 6 },
                    { 66, 3.30m, 21, 5 },
                    { 61, 3.03m, 21, 4 },
                    { 60, 5.79m, 20, 6 },
                    { 55, 2.13m, 20, 5 },
                    { 50, 4.95m, 20, 4 },
                    { 72, 8.29m, 22, 6 },
                    { 59, 3.95m, 19, 6 },
                    { 49, 4.98m, 19, 4 },
                    { 58, 6.37m, 18, 6 },
                    { 53, 0.42m, 18, 5 },
                    { 48, 1.13m, 18, 4 },
                    { 57, 8.03m, 17, 6 },
                    { 52, 1.56m, 17, 5 },
                    { 47, 2.26m, 17, 4 },
                    { 56, 4.47m, 16, 6 },
                    { 54, 4.66m, 19, 5 },
                    { 63, 6.06m, 23, 4 },
                    { 68, 8.58m, 23, 5 },
                    { 73, 7.08m, 23, 6 },
                    { 80, 9.53m, 30, 4 },
                    { 89, 5.00m, 29, 6 },
                    { 84, 8.50m, 29, 5 },
                    { 79, 8.74m, 29, 4 },
                    { 88, 6.73m, 28, 6 },
                    { 83, 2.19m, 28, 5 },
                    { 78, 3.89m, 28, 4 },
                    { 87, 5.07m, 27, 6 },
                    { 82, 0.23m, 27, 5 },
                    { 77, 7.54m, 27, 4 },
                    { 86, 8.05m, 26, 6 },
                    { 81, 9.92m, 26, 5 },
                    { 76, 7.97m, 26, 4 },
                    { 75, 7.60m, 25, 6 },
                    { 70, 0.71m, 25, 5 },
                    { 65, 1.99m, 25, 4 },
                    { 74, 9.46m, 24, 6 },
                    { 69, 7.86m, 24, 5 },
                    { 64, 7.68m, 24, 4 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Score", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 51, 3.09m, 16, 5 },
                    { 46, 3.99m, 16, 4 },
                    { 45, 9.03m, 15, 3 },
                    { 40, 8.31m, 15, 2 },
                    { 22, 3.70m, 7, 2 },
                    { 17, 0.90m, 7, 1 },
                    { 26, 5.38m, 6, 3 },
                    { 21, 1.24m, 6, 2 },
                    { 16, 2.24m, 6, 1 },
                    { 15, 9.83m, 5, 3 },
                    { 10, 9.78m, 5, 2 },
                    { 5, 5.60m, 5, 1 },
                    { 14, 0.82m, 4, 3 },
                    { 9, 7.61m, 4, 2 },
                    { 4, 0.17m, 4, 1 },
                    { 13, 1.13m, 3, 3 },
                    { 8, 6.88m, 3, 2 },
                    { 3, 4.16m, 3, 1 },
                    { 12, 9.01m, 2, 3 },
                    { 7, 9.50m, 2, 2 },
                    { 2, 3.09m, 2, 1 },
                    { 11, 9.63m, 1, 3 },
                    { 6, 0.75m, 1, 2 },
                    { 27, 6.88m, 7, 3 },
                    { 85, 8.63m, 30, 5 },
                    { 18, 1.23m, 8, 1 },
                    { 28, 2.54m, 8, 3 },
                    { 35, 2.40m, 15, 1 },
                    { 44, 2.02m, 14, 3 },
                    { 39, 4.49m, 14, 2 },
                    { 34, 1.52m, 14, 1 },
                    { 43, 6.40m, 13, 3 },
                    { 38, 8.38m, 13, 2 },
                    { 33, 8.58m, 13, 1 },
                    { 42, 7.10m, 12, 3 },
                    { 37, 9.28m, 12, 2 },
                    { 32, 5.77m, 12, 1 },
                    { 41, 4.89m, 11, 3 },
                    { 36, 3.80m, 11, 2 },
                    { 31, 2.30m, 11, 1 },
                    { 30, 4.68m, 10, 3 },
                    { 25, 8.70m, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Score", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 20, 8.32m, 10, 1 },
                    { 29, 4.89m, 9, 3 },
                    { 24, 5.86m, 9, 2 },
                    { 19, 6.37m, 9, 1 },
                    { 23, 0.05m, 8, 2 },
                    { 90, 7.53m, 30, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StudentId",
                table: "Ratings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SubjectId",
                table: "Ratings",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
